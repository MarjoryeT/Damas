using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class BoardHouse
    {
        public BoardHouse(int row, int col, Pawn pawn)
        {
            Row = row;
            Col = col;
            Pawn = pawn;
        }

        public BoardHouse(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; protected set; }
        public int Col { get; protected set; }
        public Pawn Pawn { get; protected set; }

        
    }
}
