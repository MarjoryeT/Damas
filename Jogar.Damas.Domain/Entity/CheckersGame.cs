using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class CheckersGame : EntityBase
    {
        public Guid CheckersGameId { get; protected set; }
        public Guid PlayerBlackId { get; protected set; }
        public Guid PlayerWhiteId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public virtual CheckersGame PlayerBlack { get; protected set; }
        public virtual CheckersGame PlayerWhite { get; protected set; }
        public Board Board { get; protected set; }
       
        public virtual IList<CheckersMoves> Moves { get; protected set; }
        public void NewMatch(int row, int col)
        {
            Board = new Board(8, 8);
        }
    }
}
