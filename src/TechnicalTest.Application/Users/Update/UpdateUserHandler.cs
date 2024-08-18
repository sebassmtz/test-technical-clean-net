using MediatR;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {

        private readonly IGenericRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IGenericRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get<User>(user => user.Id == request.Id);
            if (user == null)
            {
                throw new AppException("User not found");
            }
            _repository.Update<User>(user);
            await _unitOfWork.CommitChanges();
            return Unit.Value;
        }
    }
}
