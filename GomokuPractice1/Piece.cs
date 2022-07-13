using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GomokuPractice1
{
    abstract class Piece : PictureBox
    {
        Board board = new Board();
        private static readonly int PIECE_WIDTH = 50;

        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(PIECE_WIDTH, PIECE_WIDTH);
            this.Location = new Point(x - PIECE_WIDTH/2, y - PIECE_WIDTH / 2);
        }

        public abstract PieceTypes GetPieceType();
    }
}
