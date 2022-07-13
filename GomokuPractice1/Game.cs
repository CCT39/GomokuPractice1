using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GomokuPractice1
{
    class Game
    {
        private readonly Board board = new Board();
        
        private static PieceTypes currentPlayer = PieceTypes.BLACK;
        private readonly int WINNING_NODES = 5;

        private PieceTypes winner = PieceTypes.NONE;
        public PieceTypes Winner { get { return winner; } }

        public PieceTypes ChangePlayer()
        {            
            if (currentPlayer == PieceTypes.BLACK)
                currentPlayer = PieceTypes.WHITE;
            else if (currentPlayer == PieceTypes.WHITE)
                currentPlayer = PieceTypes.BLACK;

            return currentPlayer;
        }

        public static PieceTypes GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                CheckWinner();
                ChangePlayer();
                return piece;
            }
            else
                return null;
        }

        public void CheckWinner()
        {
            CheckHorizontal();
            CheckVertical();
            CheckDiagonal();
            CheckAntiDiagonal();
        }

        public void CheckHorizontal()
        {
            int lastY = board.LastPlacedNode.Y;

            int count = 0;
            for (int targetX = 0; targetX < Board.NODE_COUNT; targetX++)
            {
                int targetY = lastY;
                if (board.GetPieceType(targetX, targetY) == currentPlayer)
                {
                    count++;
                    if (count == WINNING_NODES)
                    {
                        winner = currentPlayer;
                        return;
                    }
                }
                else
                {
                    count = 0;
                }
            }
        }

        public void CheckVertical()
        {
            int lastX = board.LastPlacedNode.X;

            int count = 0;
            for (int targetY = 0; targetY < Board.NODE_COUNT; targetY++)
            {
                int targetX = lastX;
                if (board.GetPieceType(targetX, targetY) == currentPlayer)
                {
                    count++;
                    if (count == WINNING_NODES)
                    {
                        winner = currentPlayer;
                        return;
                    }
                }
                else
                {
                    count = 0;
                }
            }
        }

        public void CheckDiagonal()
        {
            int lastX = board.LastPlacedNode.X;
            int lastY = board.LastPlacedNode.Y;

            int count = 0;

            if (lastX >= lastY)
            {
                int targetY = 0;
                for (int targetX = lastX - lastY; targetX < Board.NODE_COUNT; targetX++)
                {
                    if (board.GetPieceType(targetX, targetY) == currentPlayer)
                    {
                        count++;
                        if (count == WINNING_NODES)
                        {
                            winner = currentPlayer;
                            return;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    targetY++;
                }
            } 
            else
            {
                int targetX = 0;
                for (int targetY = lastY - lastX; targetY < Board.NODE_COUNT; targetY++)
                {
                    if (board.GetPieceType(targetX, targetY) == currentPlayer)
                    {
                        count++;
                        if (count == WINNING_NODES)
                        {
                            winner = currentPlayer;
                            return;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    targetX++;
                }
            }
        }

        public void CheckAntiDiagonal()
        {
            int lastX = board.LastPlacedNode.X;
            int lastY = board.LastPlacedNode.Y;
            int sumXY = lastX + lastY;

            int count = 0;
            if (sumXY < Board.NODE_COUNT)
            {
                int targetY = 0;
                for (int targetX = sumXY; targetX >= 0; targetX--)
                {
                    if (board.GetPieceType(targetX, targetY) == currentPlayer)
                    {
                        count++;
                        if (count == WINNING_NODES)
                        {
                            winner = currentPlayer;
                            return;
                        }
                    }
                    else
                    {
                        count = 0; 
                    }
                    targetY++;
                }
            }
            else
            {
                int targetY = sumXY - Board.NODE_COUNT + 1;
                for (int targetX = Board.NODE_COUNT - 1; targetX > sumXY - Board.NODE_COUNT; targetX--)
                {
                    if (board.GetPieceType(targetX, targetY) == currentPlayer)
                    {
                        count++;
                        if (count == WINNING_NODES)
                        {
                            winner = currentPlayer;
                            return;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    targetY++;
                }
            }
        }
    }
}
