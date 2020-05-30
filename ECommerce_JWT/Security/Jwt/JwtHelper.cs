using ECommerce_Entity.Concrete.POCO;
using ECommerce_JWT.Security.Encyrtion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ECommerce_JWT.Extensions;
using System.Security.Cryptography;

namespace ECommerce_JWT.Security.Jwt
{
    public class JwtHelper
        : ITokenHelper
    {
        private IConfiguration Configuration;
        private TokenOptions tokenOptions;
        private DateTime accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(AppUser user, List<OperationClaims> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(tokenOptions, user, signingCredentials, operationClaims);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken() { Token = token, Expiration = accessTokenExpiration, RefreshToken= CreateRefreshToken() };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser user,
            SigningCredentials signingCredentials, List<OperationClaims> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials);
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(AppUser user, List<OperationClaims> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
