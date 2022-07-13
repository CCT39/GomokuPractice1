using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GomokuPractice1
{
    internal class White : Piece
    {
        public White(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }

        override public PieceTypes GetPieceType()
        {
            return PieceTypes.WHITE;
        }
    }
}
