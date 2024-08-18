
using System.Xml.Linq;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.GetAll
{
    public record UserDTO(Guid Id,string Name, string Email);
}
