using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Get
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserDTO>
    {
        private readonly IGenericRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserHandler(IGenericRepository repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitOfWork = unitofwork;
        }

        public async Task<GetUserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get<User>(user => user.Id == request.Id);
            if (user == null)
            {
                throw new AppException("User not found");
            }

            var userDto = new GetUserDTO(user.Id, user.Name, user.Email);

            return userDto;
        }
    }
}
