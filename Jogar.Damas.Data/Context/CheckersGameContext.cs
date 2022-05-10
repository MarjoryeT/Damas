using Jogar.Damas.Data.Map;
using Jogar.Damas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Data.Context
{
    
    public class CheckersGameContext : DbContext
    {
        public CheckersGameContext(DbContextOptions<CheckersGameContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        //public DbSet<CheckersGame> CheckersGame { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new CheckersGameMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
