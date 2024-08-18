using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Common.Ports
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}
