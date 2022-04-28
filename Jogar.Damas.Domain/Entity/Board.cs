using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class Board
    {
        public List<BoardHouse> Houses { get; set; }
        public List<Pawn> Pawns { get; protected set; }
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

                            Houses.Add(new BoardHouse(r, c));
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

        public void Move(Pawn pawn)
        {
            BoardHouse house = Houses.FirstOrDefault(house => house.Pawn == pawn);
        }

        public List<BoardHouse> GetAvailableHouses(Pawn pawn)
        {
            List<BoardHouse> houses = new List<BoardHouse>();
            BoardHouse house1 = new BoardHouse(pawn.Row + 1, pawn.Col - 1);
            BoardHouse house2 = new BoardHouse(pawn.Row + 1, pawn.Col + 1);
            houses.Add(house1);
            houses.Add(house2);
            return houses;
        }
        private BoardHouse GetHouse(Pawn pawn)
        {
            return Houses.FirstOrDefault(house => house.Pawn == pawn);
        }
        private bool IsPair(int value)
        {
            return value % 2 == 0;
        }
    }
}
