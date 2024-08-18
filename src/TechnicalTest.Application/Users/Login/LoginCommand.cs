using MediatR;

namespace TechnicalTest.Application.Users.Login
{

    public record LoginCommand(string Email, string Password) : IRequest<LoginDTO>;
}
