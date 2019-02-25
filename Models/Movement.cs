using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movement
    {
        private Coordinate _tentativeCoordinate;
        public Coordinate TentativeCoordinate
        {
            get { return _tentativeCoordinate; }
        }
        public Piece piece { get; set; }
        public int moves { get; set; }
        private Direction _direction;
        public Direction direction {
            get
            {
                return _direction;
            }
        }
        public Movement(Piece piece, Direction direc, int moves = 0)
        {
            this.piece = piece;
            this._direction = direc;
            this.moves = moves;
            this.DoMove();
        }
        public void DoMove()
        {
            this._tentativeCoordinate = new Coordinate(piece.coordinate.x, piece.coordinate.y);
            switch (this.direction)
            {
                case Direction.Right:
                    Right();
                    break;
                case Direction.Left:
                    Left();
                    break;
                case Direction.Forward:
                    Fordward();
                    break;
                case Direction.Backward:
                    Backward();
                    break;
                case Direction.ForwardRight:
                    FordwardRight();
                    break;
                case Direction.BackwardRight:
                    BackwardRight();
                    break;
                case Direction.ForwardLeft:
                    FordwardLeft();
                    break;
                case Direction.BackwardLeft:
                    BackwardLeft();
                    break;
                case Direction.HorseRightRightForward:
                    HorseRightRightForward();
                    break;
                case Direction.HorseRightRightBackward:
                    HorseRightRightBackward();
                    break;
                case Direction.HorseLeftLeftForward:
                    HorseLeftLeftForward();
                    break;
                case Direction.HorseLeftLeftBackward:
                    HorseLeftLeftBackward();
                    break;
                case Direction.HorseForwardForwardRight:
                    HorseForwardForwardRight();
                    break;
                case Direction.HorseForwardForwardLeft:
                    HorseForwardForwardLeft();
                    break;
                case Direction.HorseBackwardBackwardRight:
                    HorseBackwardBackwardRight();
                    break;
                case Direction.HorseBackwardBackwardLeft:
                    HorseBackwardBackwardLeft();
                    break;
            }
        }

        #region Moves

        void Fordward(int countMoves = 0)
        {
            int move;
            if (countMoves != 0)
                move = countMoves;
            else
                move = moves;

            if (piece.color == ColorPiece.Black)
            {
                _tentativeCoordinate.y = piece.coordinate.y - move;
            }
            else if (piece.color == ColorPiece.White)
                _tentativeCoordinate.y = piece.coordinate.y + move;
        }
        void Backward(int countMoves = 0)
        {
            int move;
            if (countMoves != 0)
                move = countMoves;
            else
                move = moves;

            if (piece.color == ColorPiece.Black)
                _tentativeCoordinate.y = piece.coordinate.y + move;
            else if (piece.color == ColorPiece.White)
                _tentativeCoordinate.y = piece.coordinate.y - move;
        }
        void Right(int countMoves = 0)
        {
            if (countMoves != 0)
                _tentativeCoordinate.x = piece.coordinate.x + countMoves;
            else
                _tentativeCoordinate.x = piece.coordinate.x + moves;
        }
        void Left(int countMoves = 0)
        {
            if (countMoves != 0)
                _tentativeCoordinate.x = piece.coordinate.x - countMoves;
            else
                _tentativeCoordinate.x = piece.coordinate.x - moves;
        }
        void FordwardRight()
        {
            this.Fordward();
            this.Right();
        }
        void BackwardRight()
        {
            this.Backward();
            this.Right();
        }
        void FordwardLeft()
        {
            this.Fordward();
            this.Left();
        }
        void BackwardLeft()
        {
            this.Backward();
            this.Left();
        }
        void HorseRightRightForward()
        {
            this.Right(2);
            this.Fordward(1);
        }
        void HorseRightRightBackward()
        {
            this.Right(2);
            this.Backward(1);
        }
        void HorseLeftLeftForward()
        {
            this.Left(2);
            this.Fordward(1);
        }
        void HorseLeftLeftBackward()
        {
            this.Left(2);
            this.Backward(1);
        }
        void HorseForwardForwardRight()
        {
            this.Fordward(2);
            this.Right(1);
        }
        void HorseForwardForwardLeft()
        {
            this.Fordward(2);
            this.Left(1);
        }
        void HorseBackwardBackwardRight()
        {
            this.Backward(2);
            this.Right(1);
        }
        void HorseBackwardBackwardLeft()
        {
            this.Backward(2);
            this.Right(1);
        }
        #endregion
    }
    public enum Direction
    {
        Right,
        Left,
        Forward,
        Backward,
        ForwardRight,
        BackwardRight,
        ForwardLeft,
        BackwardLeft,
        Stay,
        HorseRightRightForward,
        HorseRightRightBackward,
        HorseLeftLeftForward,
        HorseLeftLeftBackward,
        HorseForwardForwardRight,
        HorseForwardForwardLeft,
        HorseBackwardBackwardRight,
        HorseBackwardBackwardLeft,
    }
}