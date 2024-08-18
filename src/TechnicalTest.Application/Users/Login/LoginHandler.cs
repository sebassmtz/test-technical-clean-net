using MediatR;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginDTO>
    {
        private readonly IGenericRepository _repository;
        private readonly IAuthorization _authorization;
        public LoginHandler(IGenericRepository repository, IAuthorization authorization)
        {
            _repository = repository;
            _authorization = authorization;
        }

        public async Task<LoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get<User>(user => user.Email == request.Email);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            if (!user.Login(request.Email, request.Password))
            {
                throw new AppException("Invalid credentials");
            }

            var token = _authorization.GenerateToken(user);

            return new LoginDTO(token);

        }
    }
}
