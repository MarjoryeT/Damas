using Jogar.Damas.Domain.Enums;

namespace Jogar.Damas.Domain.Entity
{
    public class Pawn
    {
        public Pawn(CheckerCollor checkerCollor, BoardHouse house)
        {
            CheckerCollor = checkerCollor;
            Row = house.Row;
            Col = house.Col;
            House = house;
        }

        public string PawnId => CheckerCollor.ToString() + Row + Col;
        public bool WasCaptured { get; protected set; }
        public bool IsChecker { get; protected set; }
        public CheckerCollor CheckerCollor { get; protected set; }
        public int Row { get; protected set; }
        public int Col { get; protected set; }

        public BoardHouse House { get; protected set; }

        public void Move(BoardHouse house)
        {
            House = house;
        }

        public void Capture()
        {
            WasCaptured = true;
            House.Clear();
        }
    }
}
