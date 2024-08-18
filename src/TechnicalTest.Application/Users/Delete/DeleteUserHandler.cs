using MediatR;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {

        private readonly IGenericRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IGenericRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get<User>(user => user.Id == request.Id);
            if (user == null)
            {
                throw new AppException("User not found");
            }

            _repository.Delete<User>(user);
            await _unitOfWork.CommitChanges();
            return Unit.Value;
        }
    }
}
