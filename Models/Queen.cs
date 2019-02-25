using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Queen : Piece
    {
        private const int countOfMoves = 8;
        public Queen(ColorPiece paramColor, Coordinate initialCoordinate) :
            base(paramColor, initialCoordinate)
        {
        }
        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♛';
            else
                return '♕';
        }
        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.AddRange(this.GetAllMovesFordwardRight(countOfMoves));
            lista.AddRange(this.GetAllMovesForwardLeft(countOfMoves));
            lista.AddRange(this.GetAllMovesBackwardRight(countOfMoves));
            lista.AddRange(this.GetAllMovesBackwardLeft(countOfMoves));
            lista.AddRange(this.GetAllMovesForward(countOfMoves));
            lista.AddRange(this.GetAllMovesBackward(countOfMoves));
            lista.AddRange(this.GetAllMovesLeft(countOfMoves));
            lista.AddRange(this.GetAllMovesRight(countOfMoves));

            return lista;
        }
    }
}
