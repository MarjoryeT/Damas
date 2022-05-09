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
        public CheckersGameContext() 
        {

        }

        public DbSet<User> User { get; set; }

        //public DbSet<CheckersGame> CheckersGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=checkers.cgewd59i4zqt.us-east-1.rds.amazonaws.com;Port=5432;user id=checkers;password=YDAdARW3Pf442KwwpPB7;database=checkers");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new CheckersGameMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
