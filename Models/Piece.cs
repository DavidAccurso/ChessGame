using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Piece : Ipiece,IDisposable
    {
        private ColorPiece _color;
        public ColorPiece color { get { return _color; } }
        public Coordinate coordinate { get; set; }
        protected Chessboard _chessboard;
        public Piece(ColorPiece paramColor, Coordinate initialCoordinate)
        {
            this._color = paramColor;
            this.coordinate = initialCoordinate;
        }
        public virtual char Print() { return this.GetType().Name.ToUpper()[0]; }
        public virtual void Eat(Movement mov)
        {
            this._chessboard.Eat(mov);
        }
        public virtual void Move(Movement mov)
        {
            this._chessboard.Move(mov);
        }

        public virtual List<Movement> GetPosiblesMovements(Chessboard chessboard)
        {
            List<Movement> list = MovesOfPiece();
            List<Movement> posibleMovements = new List<Movement>();
            foreach (var item in list)
            {
                if (item.IsValidMoveOnChessboard() == false)
                    continue;
                posibleMovements.Add(item);
            }
            return posibleMovements;
        }
        public List<Movement> GetPosiblesMovements(Piece piece,Chessboard chessboard)
        {
            this._chessboard = chessboard;
            return piece.GetPosiblesMovements(chessboard);
        }

        protected abstract List<Movement> MovesOfPiece();

        #region GetAllMoves

        /// <summary>
        /// Return lista de movimientos. Al encontrar pieza en una direccion dada, termina de buscar en esa direccion.
        /// </summary>
        /// <param name="direction">Direccion</param>
        /// <param name="moves">Cantidad de movimientos en la direccion</param>
        /// <returns></returns>
        private List<Movement> GetListMoves(Direction direction, int moves)
        {
            List<Movement> list = new List<Movement>();
            for (int i = 1; i <= moves; i++)
            {
                Movement item = new Movement(this, direction, i);
                using (Piece p = _chessboard.GetPiece(item.TentativeCoordinate))
                {
                    if (p != null)
                    {
                        if (this.color == p.color)
                            return list;

                        list.Add(item);
                        return list;
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public List<Movement> GetAllMovesForward(int moves)
        {
            return GetListMoves(Direction.Forward, moves);
        }
        public List<Movement> GetAllMovesBackward(int moves)
        {
            return GetListMoves(Direction.Backward, moves);
        }
        public List<Movement> GetAllMovesRight(int moves)
        {
            return GetListMoves(Direction.Right, moves);
        }
        public List<Movement> GetAllMovesLeft(int moves)
        {           
            return GetListMoves(Direction.Left,moves);
        }
        public List<Movement> GetAllMovesFordwardRight(int moves)
        {
            return GetListMoves(Direction.ForwardRight, moves);
        }
        public List<Movement> GetAllMovesBackwardRight(int moves)
        {
            return GetListMoves(Direction.BackwardRight, moves);
        }
        public List<Movement> GetAllMovesForwardLeft(int moves)
        {
            return GetListMoves(Direction.ForwardLeft, moves);
        }
        public List<Movement> GetAllMovesBackwardLeft(int moves)
        {
            return GetListMoves(Direction.BackwardLeft, moves);
        }

        #endregion

        public void Dispose()
        {
        }
    }
    public enum ColorPiece
    {
        Black,
        White
    }
}