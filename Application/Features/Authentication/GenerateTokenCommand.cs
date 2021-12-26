using Domain.Models.Auth;
using MediatR;

namespace Application.Features.Authentication
{
    public class GenerateTokenCommand : IRequest<TokenResponse>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}