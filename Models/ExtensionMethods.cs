using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class ExtensionMethods
    {
        public static bool CompareTo(this Coordinate coord, int x, int y)
        {
            if (coord.x == x && coord.y == y)
                return true;
            return false;
        }
        public static bool CompareTo(this Coordinate coord, Coordinate coordinate)
        {
            if (coord.x == coordinate.x && coord.y == coordinate.y)
                return true;
            return false;
        }
        public static bool IsValidMoveOnChessboard(this Movement mov)
        {
            if (mov.TentativeCoordinate.x >= 1 &&
                mov.TentativeCoordinate.x <= 8 &&
                mov.TentativeCoordinate.y >= 1 &&
                mov.TentativeCoordinate.y <= 8)
                return true;
            return false;
        }
        public static void SetValues(this Coordinate coord, Coordinate parameter)
        {
            coord.x = parameter.x;
            coord.y = parameter.y;
        }
        public static ColorPiece ToogleColor(this ColorPiece colorPiece)
        {
            if (colorPiece == ColorPiece.Black)
                colorPiece = ColorPiece.White;           
            else
                colorPiece = ColorPiece.Black;

           return colorPiece;
        }
    }
}