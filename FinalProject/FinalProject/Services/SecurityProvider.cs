using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class SecurityProvider
    {
        // this stores our public/private key pair
        // usually this would be loaded from a certificate, X509Certificate2
        private RSACryptoServiceProvider rsaCrypoServiceProvider;

        public SecurityProvider()
        {
            this.rsaCrypoServiceProvider = new RSACryptoServiceProvider(2048);
        }

        public string GetToken(List<Claim> claims)
        {
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new RsaSecurityKey(this.rsaCrypoServiceProvider.ExportParameters(true)), SecurityAlgorithms.RsaSha256);
            var token = new JwtSecurityToken("www.webprogramming2017.com", "www.bethel.edu", claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(1), credentials);
            return handler.WriteToken(token);
        }

        public bool ValidateToken(string tokenString)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = "www.webprogramming2017.com",
                IssuerSigningKey = new RsaSecurityKey(this.rsaCrypoServiceProvider.ExportParameters(false)),
                ValidAudience = "www.bethel.edu"
            };

            var handler = new JwtSecurityTokenHandler();

            try
            {
                handler.ValidateToken(tokenString, validationParameters, out SecurityToken token);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}