using Jogar.Damas.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Jogar.Damas.Domain.Entity
{
    public class Board
    {
        public List<BoardHouse> Houses { get; protected set; }
        public List<Pawn> Pawns { get; protected set; }
        public Pawn SelectedPanw { get; protected set; }
        public CheckerCollor CurrentPlayer { get; protected set; }
        public List<Pawn> CapturedPawns => Pawns.Where(pawn => pawn.WasCaptured).ToList();

        public Board(int row, int col)
        {
            CurrentPlayer = CheckerCollor.WHITE;

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
                            var house = new BoardHouse(r, c, CheckerCollor.WHITE);
                            Houses.Add(house);
                            Pawns.Add(house.Pawn);
                        }
                        else if (r > rowPerPaws + 2)
                        {
                            var house = new BoardHouse(r, c, CheckerCollor.BLACK);
                            Houses.Add(house);
                            Pawns.Add(house.Pawn);
                        }
                        else
                        {
                            Houses.Add(new BoardHouse(r, c));
                        }
                    }
                }
            }

        }

        public void Move(BoardHouse house)
        {
            if (house.Available)
            {
                SelectedPanw.House.Clear();

                house.SetPanw(SelectedPanw);

                if (house.ThreatenedPawn is null)
                {
                    if (CurrentPlayer == CheckerCollor.BLACK)
                    {
                        CurrentPlayer = CheckerCollor.WHITE;
                    }
                    else
                    {
                        CurrentPlayer = CheckerCollor.BLACK;
                    }
                }
                UnavailableHouses();
            }
        }

        public void SelectPanw(Pawn pawn)
        {
            if (pawn.CheckerCollor == CurrentPlayer)
            {
                UnavailableHouses();

                var adjacentHouses = GetAdjacentHouses(pawn);

                var adversaryHouses = adjacentHouses.Where(h => h.Pawn?.CheckerCollor != pawn.CheckerCollor && !h.Empty).ToList();

                var houses = adjacentHouses.Where(h => h.Empty).ToList();
                houses.AddRange(GetAdjacentAdversaryHouses(adversaryHouses, pawn));


                houses.ForEach(h => h.MakeAvailable(true));

                SelectedPanw = pawn;
            }
        }

        public void UnavailableHouses()
        {
            Houses.ForEach(h => h.MakeAvailable(false));
        }

        private List<BoardHouse> GetAdjacentHouses(Pawn pawn)
        {
            var houses = Houses.Where(h =>
            (h.Col == pawn.House.Col - 1 || h.Col == pawn.House.Col + 1) &&
            (h.Row == pawn.House.Row + 1 || h.Row == pawn.House.Row - 1) &&
            h.Pawn?.CheckerCollor != pawn.CheckerCollor);

            if (pawn.CheckerCollor == CheckerCollor.WHITE)
                return houses.Where(h => h.Row > pawn.House.Row || (!h.Empty && h.Pawn.CheckerCollor != pawn.CheckerCollor)).ToList();
            else
                return houses.Where(h => h.Row < pawn.House.Row || (!h.Empty && h.Pawn.CheckerCollor != pawn.CheckerCollor)).ToList();
        }

        private List<BoardHouse> GetAdjacentAdversaryHouses(List<BoardHouse> houses, Pawn pawn)
        {
            List<BoardHouse> boardHouses = new List<BoardHouse>();
            foreach (var house in houses)
            {
                BoardHouse boardHouse;
                if (CurrentPlayer == CheckerCollor.WHITE)
                {
                    boardHouse = Houses.FirstOrDefault(h => (h.Col == house.Col + (house.Col - pawn.House.Col)) && h.Row == house.Row + 1);
                }
                else
                {
                    boardHouse = Houses.FirstOrDefault(h => (h.Col == house.Col + (house.Col - pawn.House.Col)) && h.Row == house.Row - 1);
                }
                if (boardHouse != null)
                {
                    boardHouse.ThreatenPawn(house.Pawn);
                    boardHouses.Add(boardHouse);
                }
            }
            return boardHouses;
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
