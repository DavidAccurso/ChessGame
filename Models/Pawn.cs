using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pawn:Piece
    {
        const int numberOfMoves = 1;
        public Pawn(ColorPiece paramColor, Coordinate initialCoordinate) :
            base(paramColor, initialCoordinate)
        {
        }
        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♟';
            else
                return '♙';
        }
        
        public override List<Movement> GetPosiblesMovements(Chessboard chessboard)
        {
            List<Movement> list = MovesOfPiece();
            List<Movement> posibleMovements = new List<Movement>();
            foreach (var item in list)
            {
                if (item.IsValidMoveOnChessboard() == false)
                    continue;
                using (Piece p = chessboard.GetPiece(item.TentativeCoordinate))
                {
                    if (item.direction == Direction.Forward)
                    {
                        if (p == null)
                            posibleMovements.Add(item);
                    }
                    else if (item.direction == Direction.ForwardRight || item.direction == Direction.ForwardLeft)
                    {
                        if (p == null)
                            continue;

                        if (p.color != item.piece.color)
                            posibleMovements.Add(item);                   
                    }
                }
            }
            return posibleMovements;
        }

        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.AddRange(this.GetAllMovesForward(numberOfMoves));
            lista.AddRange(this.GetAllMovesFordwardRight(numberOfMoves));
            lista.AddRange(this.GetAllMovesForwardLeft(numberOfMoves));

            return lista;
        }
    }
}