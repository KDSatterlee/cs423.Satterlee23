using System;

namespace EightQueens
{
    class Program
    {
        static Random randomNumbers = new Random();
        static bool[,] board; // gameboard
        static int[,] access = {
            { 22, 22, 22, 22, 22, 22, 22, 22 },
            { 22, 24, 24, 24, 24, 24, 24, 22 },
            { 22, 24, 26, 26, 26, 26, 24, 22 },
            { 22, 24, 26, 28, 28, 26, 24, 22 },
            { 22, 24, 26, 28, 28, 26, 24, 22 },
            { 22, 24, 26, 26, 26, 26, 24, 22 },
            { 22, 24, 24, 24, 24, 24, 24, 22 },
            { 22, 22, 22, 22, 22, 22, 22, 22 }
        };
        static int maxAccess = 99;
        static int queens;

        static Program()
        {
            board = new bool[8, 8];
        }

        static void Main(string[] args)
        {
            int currentRow;
            int currentColumn;

            board = new bool[8, 8];

            // Randomize initial queen position
            currentRow = randomNumbers.Next(8);
            currentColumn = randomNumbers.Next(8);

            board[currentRow, currentColumn] = true;
            ++queens;

            UpdateAccess(currentRow, currentColumn);

            bool done = false;

            while (!done)
            {
                int accessNumber = maxAccess;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (access[row, col] < accessNumber)
                        {
                            accessNumber = access[row, col];
                            currentRow = row;
                            currentColumn = col;
                        }
                    }
                }

                if (accessNumber == maxAccess)
                {
                    done = true;
                }
                else
                {
                    board[currentRow, currentColumn] = true;
                    UpdateAccess(currentRow, currentColumn);
                    ++queens;
                }
            }

            PrintBoard();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void UpdateAccess(int row, int column)
        {
            for (int i = 0; i < 8; i++)
            {
                access[row, i] = maxAccess;
                access[i, column] = maxAccess;
            }

            UpdateDiagonals(row, column);
        }

        public static void UpdateDiagonals(int rowValue, int colValue)
        {
            int row = rowValue;
            int column = colValue;

            // Upper left diagonal
            for (int diagonal = 0; diagonal < 8 && ValidMove(--row, --column); diagonal++)
                access[row, column] = maxAccess;

            row = rowValue;
            column = colValue;

            // Upper right diagonal
            for (int diagonal = 0; diagonal < 8 && ValidMove(--row, ++column); diagonal++)
                access[row, column] = maxAccess;

            row = rowValue;
            column = colValue;

            // Lower left diagonal
            for (int diagonal = 0; diagonal < 8 && ValidMove(++row, --column); diagonal++)
                access[row, column] = maxAccess;

            row = rowValue;
            column = colValue;

            // Lower right diagonal
            for (int diagonal = 0; diagonal < 8 && ValidMove(++row, ++column); diagonal++)
                access[row, column] = maxAccess;
        }

        public static bool ValidMove(int row, int column)
        {
            return (row >= 0 && row < 8 && column >= 0 && column < 8);
        }

        public static void PrintBoard()
        {
            Console.Write("  ");
            for (int k = 0; k < 8; k++)
                Console.Write(" {0}", k);

            Console.WriteLine("\n");

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write("{0} ", row);

                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column])
                        Console.Write(" Q");
                    else
                        Console.Write(" .");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n{0} queens placed on the board.", queens);
        }
    }
}
