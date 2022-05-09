using Jogar.Damas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Data.Map
{
    public class CheckersMovesMap : IEntityTypeConfiguration<CheckersMoves>
    {
        public void Configure(EntityTypeBuilder<CheckersMoves> builder)
        {
            builder.ToTable("TB_CHECKERS_MOVE");

            builder.HasKey(checkersMoves => checkersMoves.CheckersMovesId);

            builder.Property(checkersMoves => checkersMoves.CheckersGameId).HasColumnName("CHECKERS_MOVE_ID");

            builder.Property(checkersMoves => checkersMoves.EndRow).HasColumnName("END_ROW");

        }
    }
}
