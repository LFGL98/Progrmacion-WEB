using System.Linq;
using System.Collections.Generic;
using Refaccionaria.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Refaccionaria.Helpers
{
    public class UserService : IUserService
    {
        private List<Empleados> _users = new List<Empleados>()
        {
            new Empleados ()
            {
                Id = "1",
                Nombre = "Daenarys",
                Apellidos = "Targaryen",
                Telefono = "danytargaryen",
                Password = "fireandblood",
                Token = ""
            }
        };

        private readonly JWTSettings _jwtSettings;

        public UserService(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public Empleados Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Id == username && x.Password == password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim (ClaimTypes.Name, user.Id.ToString ())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;
            return user;
        }

        public IEnumerable<Empleados> GetAll()
        {
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
