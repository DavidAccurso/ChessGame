using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Bishop : Piece
    {
        private const int countOfMoves = 8;
        public Bishop(ColorPiece paramColor, Coordinate initialCoordinate) :
            base(paramColor, initialCoordinate)
        {
        }
        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♝';
            else
                return '♗';
        }

        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.AddRange(this.GetAllMovesFordwardRight(countOfMoves));
            lista.AddRange(this.GetAllMovesForwardLeft(countOfMoves));
            lista.AddRange(this.GetAllMovesBackwardRight(countOfMoves));
            lista.AddRange(this.GetAllMovesBackwardLeft(countOfMoves));

            return lista;
        }
    }
}