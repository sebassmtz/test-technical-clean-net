using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Common.Entities;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Infrastructure.EntityFramework.Contexts
{
    public  class ContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ContextApp(DbContextOptions<ContextApp> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
