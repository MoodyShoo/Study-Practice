/* Создать программу, аналог решенного судоку. 
 * В судоку используются цифры от 1 до 9-и включительно. 
 * Как известно, по правилам судоку, в одной строке длиной девять ячеек, столбце - длиной девять ячеек, и квадрате 3х3 цифры повторяться не могут. 
 * Квадрат 9х9 состоит из 9-и квадратов 3х3. 
 * Заполненный квадрат 9х9 вывести на экран.
 */

namespace Task_11
{
    class Program
    {
        private static int[,] sudokuGrid = new int[9, 9];
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            GenerateSudoku();
            PrintSudoku();
        }

        static void GenerateSudoku()
        {
            // Заполнение судоку начальными значениями
            FillDiagonal();
            FillRemaining(0, 3);
        }

        // Заполнение диагональных блоков судоку
        static void FillDiagonal()
        {
            for (int i = 0; i < 9; i += 3)
            {
                FillBox(i, i);
            }
        }

        // Заполнение остальных ячеек судоку
        static bool FillRemaining(int i, int j)
        {
            if (j >= 9 && i < 8)
            {
                i++;
                j = 0;
            }

            if (i >= 9 && j >= 9)
            {
                return true;
            }

            if (i < 3)
            {
                if (j < 3)
                {
                    j = 3;
                }
            }
            else if (i < 6)
            {
                if (j == (int)(i / 3) * 3)
                {
                    j += 3;
                }
            }
            else
            {
                if (j == 6)
                {
                    i++;
                    j = 0;
                    if (i >= 9)
                    {
                        return true;
                    }
                }
            }

            for (int num = 1; num <= 9; num++)
            {
                if (CheckIfSafe(i, j, num))
                {
                    sudokuGrid[i, j] = num;
                    if (FillRemaining(i, j + 1))
                    {
                        return true;
                    }
                    sudokuGrid[i, j] = 0;
                }
            }
            return false;
        }

        // Проверка, безопасно ли установить значение num в ячейку с координатами (row, col)
        static bool CheckIfSafe(int row, int col, int num)
        {
            return !UsedInRow(row, num) && !UsedInCol(col, num) && !UsedInBox(row - row % 3, col - col % 3, num);
        }

        // Проверка, используется ли число num в строке row
        static bool UsedInRow(int row, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudokuGrid[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        // Проверка, используется ли число num в столбце col
        static bool UsedInCol(int col, int num)
        {
            for (int row = 0; row < 9; row++)
            {
                if (sudokuGrid[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        // Проверка, используется ли число num в квадрате 3x3, начиная с (rowStart, colStart)
        static bool UsedInBox(int rowStart, int colStart, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (sudokuGrid[row + rowStart, col + colStart] == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Заполнение квадрата 3x3 начиная с (row, col)
        static void FillBox(int row, int col)
        {
            int num;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    do
                    {
                        num = rand.Next(1, 10);
                    } while (UsedInBox(row, col, num));
                    sudokuGrid[row + i, col + j] = num;
                }
            }
        }

        // Вывод судоку на экран
        static void PrintSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudokuGrid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
