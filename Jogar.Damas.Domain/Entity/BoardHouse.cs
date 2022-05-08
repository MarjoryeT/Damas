using Jogar.Damas.Domain.Enums;
using Jogar.Damas.Domain.Exceptions;

namespace Jogar.Damas.Domain.Entity
{
    public class BoardHouse
    {
        public BoardHouse(int row, int col, CheckerCollor checkerCollor)
        {
            Row = row;
            Col = col;
            Pawn = new Pawn(checkerCollor, this);
        }

        public BoardHouse(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void SetPanw(Pawn pawn)
        {
            if (Empty)
            {
                ThreatenedPawn?.Capture();
                Pawn = pawn;
                Pawn.Move(this);
            }
            else
            {
                throw new BusinessException("O peão não pode ocupar uma casa ja ocupada!!!");
            }
        }

        public void Clear()
        {
            Pawn = null;
        }


        public int Row { get; protected set; }
        public int Col { get; protected set; }
        public Pawn Pawn { get; protected set; }
        public bool Empty => Pawn is null;
        public Pawn ThreatenedPawn { get; protected set; }
        public bool Available { get; protected set; }

        public void MakeAvailable(bool available)
        {
            Available = available;
            if (!available)
            {
                ThreatenedPawn = null;
            }
        }

        public void ThreatenPawn(Pawn pawn)
        {
            ThreatenedPawn = pawn;
        }

    }
}
