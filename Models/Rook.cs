using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Rook : Piece
    {
        const int numberOfMoves = 7;
        public Rook(ColorPiece paramColor, Coordinate initialCoordinate) :
            base(paramColor, initialCoordinate)
        {
        }
        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♜';
            else
                return '♖';
        }

        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.AddRange(this.GetAllMovesForward(numberOfMoves));
            lista.AddRange(this.GetAllMovesBackward(numberOfMoves));
            lista.AddRange(this.GetAllMovesLeft(numberOfMoves));
            lista.AddRange(this.GetAllMovesRight(numberOfMoves));

            return lista;
        }
    }
}
