using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Main2.Controllers
{
    public class ChessController : Controller
    {
        private List<Movement> actualPosibleMovements
        {
            get
            {
                return (List<Movement>)Session["actualPosibleMovements"];
            }
            set
            {
                Session["actualPosibleMovements"] = value;
            }
        }
        private Chessboard chessboard {
            get
            {
                if (this.Session["chessboard"] == null)
                    Session["chessboard"] = new Chessboard();

                return (Chessboard)Session["chessboard"];
            }           
        }
        private Piece actualPieceSelected
        {
            get
            {
                return this.chessboard.actualPieceSelected;
            }
            set
            {
                this.chessboard.actualPieceSelected = value;
            }
        }
        private ColorPiece colorWhoMove
        {
            get
            {
                if (Session["color"] == null)
                {
                    Session["color"] = ColorPiece.White;
                }
                return (ColorPiece)Session["color"];
            }
            set
            {
                Session["color"] = value;
            }
        }

        public ChessController()
        {
        }
        // GET: Chess
        public ActionResult Index()
        {
            return View(chessboard);
        }

        [HttpGet]
        public void StartNewGame() //JS: btnNewGame click
        {
            Session["chessboard"] = new Chessboard();
            actualPosibleMovements = null;
            colorWhoMove = ColorPiece.White;
            actualPieceSelected = null;
            this.Index();
        }

        [HttpPost]
        public JsonResult Move(int x, int y) //JS: move
        {
            Movement actual = this.actualPosibleMovements.Where(w => w.TentativeCoordinate.CompareTo(x, y)).FirstOrDefault();
            if (actual == null)
                throw new HttpRequestValidationException("No se encontro el movimiento seleccionado");

            bool fin = this.chessboard.Move(actual);
            JsonResult result;
            this.chessboard.colorMoved = colorWhoMove.ToString().ToUpper();//Color que movio
            colorWhoMove = colorWhoMove.ToogleColor();
            this.chessboard.colorWhoDoMove = colorWhoMove.ToString().ToUpper();//color que le toca mover
            result = Json(new { colorMoved = actual.piece.color, color = colorWhoMove, resultado = fin});
            return result;
        }

        [HttpGet]
        public JsonResult GetPosiblesMovements(int x, int y) //JS: clickPiece
        {
            Piece piece = this.chessboard.GetPiece(new Coordinate(x,y));
            if (piece != null)
            {
                if (piece.color == colorWhoMove)
                {
                    actualPieceSelected = piece;
                    actualPosibleMovements = this.chessboard.GetPosiblesMovements(x, y);
                    if (actualPosibleMovements == null)
                        return Json(string.Empty);

                    return Json(actualPosibleMovements, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}