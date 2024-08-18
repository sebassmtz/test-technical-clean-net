

using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.GetAll
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, GetAllUserDTO>
    {
        private readonly IGenericRepository _repository;

        public GetAllUserHandler(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllUserDTO> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll<User>();

            var userDTOs = users.Select(user => new UserDTO(user.Id, user.Name, user.Email)).ToList();
            return new GetAllUserDTO(userDTOs);
        }
    }
}
