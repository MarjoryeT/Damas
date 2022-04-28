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
        public virtual User PlayerBlack { get; protected set; }
        public virtual User PlayerWhite { get; protected set; }
        public Board Board { get; protected set; }
       
        public virtual IList<CheckersMoves> Moves { get; protected set; }
        public void NewMatch()
        {
            
        }
    }
}
