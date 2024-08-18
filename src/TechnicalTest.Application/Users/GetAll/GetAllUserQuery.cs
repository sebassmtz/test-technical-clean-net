using MediatR;

namespace TechnicalTest.Application.Users.GetAll
{
    public record GetAllUserQuery() : IRequest<GetAllUserDTO>;
}
