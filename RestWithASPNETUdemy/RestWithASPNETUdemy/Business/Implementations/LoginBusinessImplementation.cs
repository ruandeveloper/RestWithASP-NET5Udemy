using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LoginBusinessImplementation: ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        
        private TokenConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            
            _repository.RefreshUserInfo(user);
            
            var createDate = DateTime.Now;
            var expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                authenticated: true,
                created: createDate.ToString(DATE_FORMAT),
                expiration: expirationDate.ToString(DATE_FORMAT),
                accessToken: accessToken,
                refreshToken: refreshToken);
        }
    }
}