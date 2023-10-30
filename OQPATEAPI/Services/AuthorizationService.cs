using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using OQPATE.API.common;
using OQPATE.DB;
using OQPATE.DB.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace OQPATE.API.Services
{
    public class AuthorizationService : IAuthorizationServices
    {
        private readonly IConfiguration _configuration;
        private readonly MySQLContext _context;
        public AuthorizationService(MySQLContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        private string GenerateToken(string idUsuario)
        {

            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim( new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

           
            return tokenHandler.WriteToken(tokenConfig);
        }


        public async Task<AuthorizationResponse> GetAuthorizationResponseAsync(AuthorizationRequest request)
        {
            var salt = _context.Users.FirstOrDefault(x => x.UserName == request.Username).Salt;
            var EnteredPass = common.Utility.HashString(request.Password, salt);

            var userFound = _context.Users.FirstOrDefault(q
                => q.UserName == request.Username
                && q.UserPassword == EnteredPass
                );

            string GeneratedToken = userFound != null ? GenerateToken(userFound.UserName) : "";

            return new AuthorizationResponse()
            {
                Token = GeneratedToken,
                Result = userFound != null ? true : false,
                Msg = userFound != null ? "OK" : "Login Fail"
            };
        }
    }
}
