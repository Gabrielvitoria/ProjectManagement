﻿using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Common;
using ProjectManagement.Common.AlterDto;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Services.Project
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;

        public TokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Tuple<string, string> GenerateToken(string username, string password)
        {
            var user = _userRepository.Get(username, password);

            if (user == null)
            {
                throw new ApplicationException($"Error: There is no user with informed credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Tuple.Create<string, string>(user.Username, tokenHandler.WriteToken(token));
        }
    }
}
