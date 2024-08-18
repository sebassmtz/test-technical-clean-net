using MediatR;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IGenericRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IGenericRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get<User>(user => user.Email == request.Email
            );
            if (user != null)
            {
                throw new AppException("User already exists");
            }
            var createUser = User.Create(request.Name, request.Email, request.Password);
            _repository.Save<User>(createUser);
            await _unitOfWork.CommitChanges();
            var userDTO = new CreateUserDTO(createUser.Id, createUser.Name, createUser.Email);
            return userDTO;

        }
    }
}
