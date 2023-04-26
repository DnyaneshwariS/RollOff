using Microsoft.EntityFrameworkCore;
using RollOff.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Data
{
    public class RollOffDBContext:DbContext
    {
        public RollOffDBContext(DbContextOptions<RollOffDBContext>options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<FeedbackForm> FeedbackForm { get; set; }
        public DbSet<AssignedFrom> AssignedFrom { get; set; }
        public DbSet<RollOffForm> RollOffForm { get; set; }
        public DbSet<TransferedFrom> TransferedFrom { get; set; }
    }
}
