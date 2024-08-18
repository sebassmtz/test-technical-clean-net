

using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Infrastructure.Authentication
{
    public class AuthenticationProvider : IAuthorization
    {
        public string GenerateToken(User user)
        {
            return "token";
        }
    }
}
