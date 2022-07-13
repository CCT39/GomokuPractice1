using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GomokuPractice1
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        
        private static readonly int OFFSET = 75;
        private static readonly int NODE_DISTANCE = 75;
        private static readonly int NODE_RADIUS = 15;
        public static readonly int NODE_COUNT = 9;

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];

        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }

        public PieceTypes GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceTypes.NONE;
            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();
            }
        }

        public Point ConvertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point
            {
                X = nodeId.X * NODE_DISTANCE + OFFSET,
                Y = nodeId.Y * NODE_DISTANCE + OFFSET
            };
            return formPosition;
        }

        public Piece PlaceAPiece(int x, int y, PieceTypes player)
        {            
            Point nodeId = FindTheClosestNode(x, y);

            if ( ! CanBePlaced(x, y) )
                return null;

            Point formPos = ConvertToFormPosition(nodeId);
            if (player == PieceTypes.BLACK)
                pieces[nodeId.X, nodeId.Y] = new Black(formPos.X, formPos.Y);
            else if (player == PieceTypes.WHITE)
                pieces[nodeId.X, nodeId.Y] = new White(formPos.X, formPos.Y);

            // 記錄最後下棋子的位置
            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];
        }

        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點
            Point nodeId = FindTheClosestNode(x, y);
            // 如果找不到，或節點已有棋子，回傳 false
            if (nodeId == NO_MATCH_NODE || pieces[nodeId.X, nodeId.Y] != null) 
                return false;
            else
                return true;
        }

        public Point FindTheClosestNode(int x, int y)
        {
            int nodeIdX = FindTheClosestNode(x);
            int nodeIdY = FindTheClosestNode(y);
            if (nodeIdX < 0 || nodeIdY < 0)
                return NO_MATCH_NODE;
            else
                return new Point(nodeIdX, nodeIdY);
        }

        public int FindTheClosestNode(int pos)
        {
            int quotient = (pos - OFFSET) / NODE_DISTANCE;
            int remainder = (pos - OFFSET) % NODE_DISTANCE;
            if (quotient < NODE_COUNT && quotient >= 0 && pos >= OFFSET - NODE_RADIUS)
            {
                if (remainder <= NODE_RADIUS)
                    return quotient;
                else if (quotient < 8 && remainder >= NODE_DISTANCE - NODE_RADIUS)
                    return quotient + 1;
                else
                    return -1;
            }
            else
                return -1;
        }
    }
}
