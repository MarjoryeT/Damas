﻿using Jogar.Damas.Domain.Entity;
using System.Linq;

Board board = new Board(8, 8);
board.GetAvailableHouses(board.Pawns.FirstOrDefault(p=> p.Row == 3));