using System.Collections.Generic;
using System.Linq;

namespace Jogar.Damas.Domain.Entity
{
    public class Board
    {
        public List<BoardHouse> Houses { get; protected set; }
        public List<Pawn> Pawns { get; protected set; }

        public Pawn SelectedPanw { get; protected set; }

        public Board(int row, int col)
        {
            Houses = new List<BoardHouse>();
            Pawns = new List<Pawn>();

            int rowPerPaws = (row - 2) / 2;

            for (int r = 1; r <= row; r++)
            {
                for (int c = 1; c <= col; c++)
                {
                    if (IsPair(r) == IsPair(c))
                    {

                        if (r <= rowPerPaws)
                        {
                            Pawn pawn = new Pawn(Enums.CheckerCollor.WHITE, r, c);

                            Houses.Add(new BoardHouse(r, c, pawn));
                            Pawns.Add(pawn);
                        }
                        else if (r > rowPerPaws + 2)
                        {
                            Pawn pawn = new Pawn(Enums.CheckerCollor.BLACK, r, c);

                            Houses.Add(new BoardHouse(r, c, pawn));
                            Pawns.Add(pawn);
                        }
                        else
                        {
                            Houses.Add(new BoardHouse(r, c));
                        }
                    }
                }
            }

        }

        public void Move(BoardHouse newHouse)
        {
            if (newHouse.Available)
            {
                BoardHouse actualHouse = GetHouse(SelectedPanw);
                actualHouse.Clear();
                newHouse.SetPanw(SelectedPanw);
                UnavailableHouses();
            }
        }

        public void SelectPanw(Pawn pawn)
        {
            var adjacentHouses = GetAdjacentHouses(pawn);

            var adversaryHouses = adjacentHouses.Where(h => h.Pawn?.CheckerCollor != pawn.CheckerCollor && !h.Empty).ToList();

            var houses = adjacentHouses.Where(h => h.Empty).ToList();

            houses.AddRange(GetAdjacentAdversaryHouses(adversaryHouses, pawn));

            UnavailableHouses();

            houses.ForEach(h => h.MakeAvailable(true));

            SelectedPanw = pawn;
        }

        public void UnavailableHouses()
        {
            Houses.ForEach(h => h.MakeAvailable(false));
        }

        private List<BoardHouse> GetAdjacentHouses(Pawn pawn)
        {
            BoardHouse house = GetHouse(pawn);
            return Houses.Where(h => (h.Col == house.Col - 1 || h.Col == house.Col + 1) && h.Row == house.Row + 1).ToList();
        }

        private List<BoardHouse> GetAdjacentAdversaryHouses(List<BoardHouse> houses, Pawn pawn)
        {
            List<BoardHouse> boardHouses = new List<BoardHouse>();
            foreach (var house in houses)
            {
                var boardHouse = Houses.FirstOrDefault(h => (h.Col == house.Col + (house.Col - pawn.Col)) && h.Row == house.Row + 1);
                boardHouses.Add(boardHouse);
            }
            return boardHouses;
        }

        private BoardHouse GetHouse(Pawn pawn)
        {
            return Houses.FirstOrDefault(house => house.Pawn == pawn);
        }

        public BoardHouse GetHouse(int row, int col)
        {
            return Houses.FirstOrDefault(house => house.Row == row && house.Col == col);
        }

        private bool IsPair(int value)
        {
            return value % 2 == 0;
        }
    }
}
