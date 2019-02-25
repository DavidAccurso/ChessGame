using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class ChessboardSingleton
    {
        private static Chessboard _chessboard;
        private static Chessboard chessboard
        {
            get
            {
                if (_chessboard == null)
                    _chessboard = new Models.Chessboard();
                return _chessboard;
            }
        }
        public static Chessboard GetChessboard()
        {
            return chessboard;
        }
    }
}
