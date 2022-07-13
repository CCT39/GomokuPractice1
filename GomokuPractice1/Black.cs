using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GomokuPractice1
{
    internal class Black : Piece
    {
        public Black(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }

        override public PieceTypes GetPieceType()
        {
            return PieceTypes.BLACK;
        }
    }
}
