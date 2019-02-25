using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Knight:Piece
    {
        public Knight(ColorPiece paramColor,Coordinate initialCoordinate) : base(paramColor, initialCoordinate)
        {
        }

        public override char Print()
        {
            if (this.color == ColorPiece.Black)
                return '♞';
            else
                return '♘';
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

        protected override List<Movement> MovesOfPiece()
        {
            List<Movement> lista = new List<Movement>();
            lista.Add(new Movement(this,Direction.HorseBackwardBackwardLeft));
            lista.Add(new Movement(this, Direction.HorseBackwardBackwardRight));
            lista.Add(new Movement(this, Direction.HorseForwardForwardLeft));
            lista.Add(new Movement(this, Direction.HorseForwardForwardRight));
            lista.Add(new Movement(this, Direction.HorseLeftLeftBackward));
            lista.Add(new Movement(this, Direction.HorseLeftLeftForward));
            lista.Add(new Movement(this, Direction.HorseRightRightBackward));
            lista.Add(new Movement(this, Direction.HorseRightRightForward));

            return lista;
        }
    }
}