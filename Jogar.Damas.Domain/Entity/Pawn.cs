using Jogar.Damas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class Pawn
    {
        public Pawn(CheckerCollor checkerCollor, int row, int col)
        {
            CheckerCollor = checkerCollor;
            Row = row;
            Col = col;
        }

        public string PawnId => CheckerCollor.ToString() + Row + Col;
        public bool WasCaptured { get; protected set; }
        public bool IsChecker { get; protected set; }
        public CheckerCollor CheckerCollor { get; protected set; }
        public int Row { get; protected set; }
        public int Col { get; protected set; }
    }
}
