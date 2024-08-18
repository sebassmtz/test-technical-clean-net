using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Infrastructure.EntityFramework.Contexts;

namespace TechnicalTest.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ContextApp _context;

        public UnitOfWork(ContextApp context)
        {
            _context = context;
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
