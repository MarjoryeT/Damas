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
    public class CheckersGameMap : IEntityTypeConfiguration<CheckersGame>
    {
        public void Configure(EntityTypeBuilder<CheckersGame> builder)
        {
            builder.ToTable("TB_CHECKERS_GAME");

            builder.HasKey(checkersGame => checkersGame.CheckersGameId);

            builder.Property(checkersGame => checkersGame.CheckersGameId).HasColumnName("CHECKERS_GAME_ID");

            builder.Property(checkersGame => checkersGame.PlayerBlackId).HasColumnName("PLAYER_BLACK_ID");

            builder.Property(checkersGame => checkersGame.PlayerWhiteId).HasColumnName("PLAYER_WHITE_ID");

            builder.Property(checkersGame => checkersGame.StartDate)
                .HasColumnName("START_DATE")
                .IsRequired();

            builder.Ignore(checkersGame => checkersGame.Board);

        }
    }
}