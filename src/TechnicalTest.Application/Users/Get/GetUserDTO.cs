using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Application.Users.Get
{
    public record GetUserDTO(Guid Id, string Name, string Email);
}
