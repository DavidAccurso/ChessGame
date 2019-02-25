using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coordinate
    {
        public int x{ get; set; }
        public int y { get; set; }
        public Coordinate(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }
}