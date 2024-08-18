
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Create
{
    public record CreateUserDTO(Guid Id, string Name, string Email);
}
