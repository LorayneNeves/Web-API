using Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApplication1.Token
{
    public class TokenService
    {
        public static string GenerateToken(Usuario user)
        {
            var tokenHand = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new 
        }
    }
}
