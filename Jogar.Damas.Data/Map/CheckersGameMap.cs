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
            builder.ToTable("TB_CHECKERSGAME");

            builder.HasKey(checkersGame => checkersGame.CheckersGameId);

            builder.Property(checkersGame => checkersGame.CheckersGameId).HasField("CHECKERS_GAME_ID");

            builder.Property(checkersGame => checkersGame.PlayerBlackId).HasField("PLAYER_BLACK_ID");

            builder.Property(checkersGame => checkersGame.PlayerWhiteId).HasField("PLAYER_WHITE_ID");

            builder.Property(checkersGame => checkersGame.StartDate)
                .HasColumnName("START_DATE")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(checkersGame => checkersGame.PlayerBlack)
                .HasColumnName("PLAYER_BLACK")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(checkersGame => checkersGame.PlayerWhite)
                 .HasColumnName("PLAYER_WHITE")
                 .HasMaxLength(50)
                 .HasColumnType("VARCHAR")
                 .IsRequired();

            builder.Property(checkersGame => checkersGame.Board)
                .HasColumnName("BOARD")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

           

        }

    }
}