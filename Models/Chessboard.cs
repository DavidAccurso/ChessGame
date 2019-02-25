using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Chessboard
    {
        public Piece actualPieceSelected { get; set; }
        public string colorWhoDoMove { get; set; }
        public string colorMoved { get; set; }

        private List<Piece> _pieces;
        public List<Piece> pieces { get { return _pieces; } }
        private Coordinate GetAleatoryCoordinate()
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                if (pieces.Where(w => w.coordinate.CompareTo(x, y)).Any() == false)
                    return new Coordinate(x,y);
            }
            throw new Exception("Error al generar numero aleatorio./nmethod: constructor of Chessboard, calling method: GetAleatoryCoordinate - class: Models.Chessboard");
        }
        public Chessboard()
        {
            _pieces = new List<Piece>();

            #region Dictionary coordinates

            //White
            _pieces.Add(PiecesFactory.Create(ChessResources.Rook, ColorPiece.White, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Rook, ColorPiece.White, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.Knight, ColorPiece.White, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Knight, ColorPiece.White, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.Bishop, ColorPiece.White, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Bishop, ColorPiece.White, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.King, ColorPiece.White, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Queen, ColorPiece.White, this.GetAleatoryCoordinate()));

            for (int i = 1; i <= 8; i++)
                _pieces.Add(PiecesFactory.Create(ChessResources.Pawn, ColorPiece.White, this.GetAleatoryCoordinate()));

            ////Black
            _pieces.Add(PiecesFactory.Create(ChessResources.Rook, ColorPiece.Black, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Rook, ColorPiece.Black, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.Knight, ColorPiece.Black, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Knight, ColorPiece.Black, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.Bishop, ColorPiece.Black, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Bishop, ColorPiece.Black, this.GetAleatoryCoordinate()));

            _pieces.Add(PiecesFactory.Create(ChessResources.King, ColorPiece.Black, this.GetAleatoryCoordinate()));
            _pieces.Add(PiecesFactory.Create(ChessResources.Queen, ColorPiece.Black, this.GetAleatoryCoordinate()));

            for (int i = 1; i <= 8; i++)
            {
                _pieces.Add(PiecesFactory.Create(ChessResources.Pawn, ColorPiece.Black, this.GetAleatoryCoordinate()));
            };
            #endregion

            this.colorWhoDoMove = "WHITE";
        }
        public void Eat(Movement movement)
        {
            using (Piece p = this.GetPiece(movement.piece.coordinate))
            {
                Piece eatedPiece = this.pieces.Where(x => x.coordinate.CompareTo(movement.TentativeCoordinate)).FirstOrDefault();
                this.pieces.Remove(eatedPiece);
                p.coordinate.SetValues(movement.TentativeCoordinate);
            }
        }
        public bool Move(Movement movement)
        {
            using (Piece p = this.GetPiece(movement.TentativeCoordinate))
            {
                if (p == null) // movimiento a celda vacia
                {
                    this.pieces.
                        Where(x => x.coordinate.CompareTo(movement.piece.coordinate)).
                        FirstOrDefault().
                        coordinate.SetValues(movement.TentativeCoordinate);
                    return true;
                }
                else //come
                {
                    this.Eat(movement);
                    if (p.GetType() == typeof(King)) //Si come rey, termina juego -> return false;
                        return false;

                    return true; 
                }
            }
        }
        public List<Movement> GetPosiblesMovements(int x, int y)
        {
            Coordinate coordinate = new Coordinate(x, y);
            Piece piece = this.GetPiece(coordinate);
            if (piece == null)
                return null;

            return piece.GetPosiblesMovements(piece, this);
        }
        public Piece GetPiece(Coordinate coordinate)
        {
            if (pieces.Any() == false)
                return null;
            Piece piece = pieces.Where(x => x.coordinate.CompareTo(coordinate)).FirstOrDefault();
            return piece;
        }
    }
}