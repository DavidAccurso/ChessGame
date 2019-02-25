using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Models
{
    public static class PiecesFactory
    {
        public static Piece Create(string type, ColorPiece color, Coordinate coor)
        {
            if (type == ChessResources.Rook)
                return new Rook(color, coor);

            else if (type == ChessResources.Knight)
                return new Knight(color, coor);

            else if (type == ChessResources.Bishop)
                return new Bishop(color, coor);

            else if (type == ChessResources.Queen)
                return new Queen(color, coor);

            if (type == ChessResources.King)
                return new King(color, coor);

            else if (type == ChessResources.Pawn)
                return new Pawn(color, coor);

            return null;
        }
    }
}