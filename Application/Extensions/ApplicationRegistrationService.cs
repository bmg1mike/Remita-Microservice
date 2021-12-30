using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using FluentValidation;
using Infrastructure.Helpers;
using Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;

namespace Application.Extensions
{
    public static class ApplicationRegistrationService
    {
        //private Logger<ApplicationRegistrationService> logger = new ILogger<ApplicationRegistrationService>();
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IHttpCommunication,HttpCommunication>();
            services.AddScoped<ITransactionStatusService,TransactionStatusService>();
            services.AddScoped<ILendingSupportService,LendingSupportService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IFundTransferService,FundTransferService>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IReferenceDataService,ReferenceDataService>();
            services.AddScoped<IBillerAggregationService,BillerAggregationService>();
            // services.AddHttpClient<ITransactionStatusService,TransactionStatusService>(x =>
            //     x.BaseAddress = new Uri(config["Remita:BaseUrl"]))
            //     .AddPolicyHandler(GetRetryPolicy())
            //     .AddPolicyHandler(GetCircuitBreakerPolicy());
            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // In this case will wait for
            //  2 ^ 1 = 2 seconds then
            //  2 ^ 2 = 4 seconds then
            //  2 ^ 3 = 8 seconds then
            //  2 ^ 4 = 16 seconds then
            //  2 ^ 5 = 32 seconds

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, retryCount, context) =>
                    {
                        //Logger<ApplicationRegistrationService>.($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                    });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
        }
    }
}