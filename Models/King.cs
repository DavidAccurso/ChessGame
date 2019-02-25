using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class King: Piece
    {
        const int numberOfMoves = 1;
        public King(ColorPiece paramColor, Coordinate initialCoordinate) :
            base(paramColor, initialCoordinate)
        {
        }
        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♚';
            else
                return '♔';
        }
        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.AddRange(this.GetAllMovesForward(numberOfMoves));
            lista.AddRange(this.GetAllMovesBackward(numberOfMoves));
            lista.AddRange(this.GetAllMovesRight(numberOfMoves));
            lista.AddRange(this.GetAllMovesLeft(numberOfMoves));
            lista.AddRange(this.GetAllMovesFordwardRight(numberOfMoves));
            lista.AddRange(this.GetAllMovesBackwardRight(numberOfMoves));
            lista.AddRange(this.GetAllMovesForwardLeft(numberOfMoves));
            lista.AddRange(this.GetAllMovesBackwardLeft(numberOfMoves));

            return lista;
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
                    if (p == null || p.color != item.piece.color)
                        posibleMovements.Add(item);
                }
            }
            return posibleMovements;
        }
    }
}