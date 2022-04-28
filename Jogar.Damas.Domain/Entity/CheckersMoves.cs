using Jogar.Damas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class CheckersMoves
    {
        public Guid CheckersMovesId { get; protected set; }
        public Guid CheckersGameId { get; protected set; }
        public CheckerCollor CheckerCollor { get; protected set; }
        public int StartRow { get; protected set; }
        public int StartCol { get; protected set; }
        public int EndRow { get; protected set; }
        public int EndCol { get; protected set; }
        public int Order { get; protected set; }
        public string Pawn  { get; protected set; }                                                                                                                                                                         
    }
}
