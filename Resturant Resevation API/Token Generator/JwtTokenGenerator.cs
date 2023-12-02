using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MinimalASP.NETWebAPI
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }
        public string GenerateToken(string username, string password)
        {
            // Validate user credentials
            if (ValidateUserCredentials(username, password))
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII
                    .GetBytes(_configuration["Authentication:SecretForKey"]!));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30), // Adjust the expiration time as needed
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null!; // Invalid credentials
        }
        private bool ValidateUserCredentials(string? userName, string? password)
        {
            return userName == "omar" && password == "123";
        } 
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]!));

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = _configuration["Authentication:Issuer"],
                    ValidAudience = _configuration["Authentication:Audience"],
                    IssuerSigningKey = key
                }, out _);
                return true; // Token is valid
            }
            catch
            {
                return false; // Token validation failed
            }
        }
    }
}
