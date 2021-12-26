using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Auth;

namespace Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> GetAccessToken(TokenRequest request);
    }
}