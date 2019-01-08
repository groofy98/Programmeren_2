using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Enumerations;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            ChessPiece[,] chessboard = new ChessPiece[8, 8];
            InitChessboard(ref chessboard);
            DisplayChessboard(chessboard);
            PlayChess(chessboard);
            Console.ReadKey();

        }

        void InitChessboard(ref ChessPiece[,] chessboard)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    chessboard[x, y] = null;
                }
            }
            PutChessPieces(ref chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            Console.Write("   ");
            for (int i = 0; i < 8; i++)
            {

                Console.Write(" {0} ", Convert.ToChar(i + 65));
            }
            Console.WriteLine();
            for (int y = 0; y < 8; y++)
            {
                Console.Write(" {0} ", y + 1);
                for (int x = 0; x < 8; x++)
                {
                    if ((x + y) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    DisplayChessPiece(chessboard[x, y]);
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            bool b = true;
            while (b)
            {                
                Position from = ReadPosition("waar van?");
                Position to = ReadPosition("waar naar toe?");
                CheckMove(ref chessboard, from, to);
                Console.Clear();
                DisplayChessboard(chessboard);
            }
        }

        void PutChessPieces(ref ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.King, ChessPieceType.Queen, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };
            for (int x = 0; x < 8; x++)
            {
                ChessPiece piece = new ChessPiece();
                piece.color = ChessPieceColor.White;
                piece.type = order[x];
                chessboard[x, 0] = piece;
                ChessPiece pawn = new ChessPiece();
                pawn.color = ChessPieceColor.White;
                pawn.type = ChessPieceType.Pawn;
                chessboard[x, 1] = pawn;
            }
            for (int x = 0; x < 8; x++)
            {
                ChessPiece piece = new ChessPiece();
                piece.color = ChessPieceColor.Black;
                piece.type = order[x];
                chessboard[x, 7] = piece;
                ChessPiece pawn = new ChessPiece();
                pawn.color = ChessPieceColor.Black;
                pawn.type = ChessPieceType.Pawn;
                chessboard[x, 6] = pawn;
            }
        }

        void DisplayChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece != null)
            {
                if (chessPiece.color == ChessPieceColor.Black)
                    Console.ForegroundColor = ConsoleColor.Black;
                switch (chessPiece.type)
                {
                    case ChessPieceType.Pawn:
                        Console.Write(" p ");
                        break;
                    case ChessPieceType.Bishop:
                        Console.Write(" b ");
                        break;
                    case ChessPieceType.King:
                        Console.Write(" K ");
                        break;
                    case ChessPieceType.Knight:
                        Console.Write(" k ");
                        break;
                    case ChessPieceType.Queen:
                        Console.Write(" Q ");
                        break;
                    case ChessPieceType.Rook:
                        Console.Write(" r ");
                        break;
                    default:
                        Console.Write("  ");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write("   ");
        }

        Position ReadPosition(string question)
        {
            Position p = new Position();
            try
            {

                Console.WriteLine(question);
                string userPos = Console.ReadLine();
                p.column = userPos[0] - 'A';
                p.row = int.Parse(userPos[1].ToString()) - 1;
                if (p.row < 0 || p.row > 7 || p.column < 0 || p.column > 7)
                    throw new Exception("Invalid position");
            }
            catch
            {
                Console.WriteLine("incorrecte positie ingevoerd");
                p = ReadPosition("probeer opnieuw");
            }

            return p;
        }

        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {

        }

        void CheckMove(ref ChessPiece[,] chessboard, Position from, Position to)
        {
            if (chessboard[from.column, from.row] != null)
            {
                if (chessboard[to.column, to.row] == null || chessboard[to.column, to.row].color != chessboard[from.column, from.row].color)
                {
                    if (ValidMove(chessboard[from.column, from.row], from, to))
                    {
                        chessboard[to.column, to.row] = chessboard[from.column, from.row];
                        chessboard[from.column, from.row] = null;

                    }
                }
            }
            else { throw new Exception("no piece found"); }
        }

        bool ValidMove(ChessPiece chessPiece, Position from, Position to)
        {
            bool valid = false;
            int hor = Math.Abs(from.column - to.column);
            int ver = Math.Abs(from.row - to.row);
            switch (chessPiece.type)
            {
                case ChessPieceType.Rook:
                    if (hor * ver == 0)
                        valid = true;
                    break;
                case ChessPieceType.Pawn:
                    if (hor == 0 && ver == 1)
                        valid = true;
                    break;
                case ChessPieceType.Bishop:
                    if (hor == ver)
                        valid = true;
                    break;
                case ChessPieceType.King:
                    if (hor == 1 || ver == 1)
                        valid = true;
                    break;
                case ChessPieceType.Knight:
                    if (hor * ver == 2)
                        valid = true;
                    break;
                case ChessPieceType.Queen:
                    if (hor * ver == 0 || hor == ver)
                        valid = true;
                    break;
            }

            return valid;
        }
    }
}
