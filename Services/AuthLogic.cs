using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoBHo_UserService.Helpers;
using RoBHo_UserService.Models;
using RoBHo_UserService.repositories;
using RoBHo_UserService.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoBHo_UserService.Services
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IUserRepository _repository;
        private readonly AppSettings _appSettings;

        public AuthLogic(IOptions<AppSettings> appSettings, IUserRepository repository)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = _repository.GetUserByCredentials(model.Username, model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public bool Register(RegisterRequest model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };
            return _repository.AddUser(user);
        }

        // helper methods
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
