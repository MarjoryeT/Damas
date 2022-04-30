using Jogar.Damas.Domain.Exceptions;

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

        public void SetPanw(Pawn pawn)
        {
            if (Empty)
                Pawn = pawn;
            else
                throw new BusinessException("O peão não pode ocupar uma casa ja ocupada!!!");
        }

        public void Clear()
        {
            Pawn = null;
        }


        public int Row { get; protected set; }
        public int Col { get; protected set; }
        public Pawn Pawn { get; protected set; }
        public bool Empty => Pawn is null;

        public bool Available { get; protected set; }

        public void MakeAvailable(bool available)
        {
            Available = available;
        }

    }
}
