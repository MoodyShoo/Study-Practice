/*
 * Задача 5
 * Даны координаты нахождения коня на шахматной доске. 
 * Требуется определить, бьет ли конь фигуру, стоящую на другой указанной клетке за один ход. 
 * Координаты коня и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
 * В качестве выходного сообщения выводится одна из строк: "Конь сможет побить фигуру", "Конь не сможет побить фигуру", "Введены некорректные координаты"
 */

using System.IO;

namespace Task_05
{
    class Program
    {
        static void ErrorOutput()
        {
            Console.WriteLine("Вы ввели некорректные координаты");
        }

        static bool CheckCoords(string coords)
        {
            return (coords[0] >= 'a' && coords[0] <= 'h') &&
                   (coords[1] >= '1' && coords[1] <= '8');
        }

        static bool CheckOneMove(string coordsKnight, string coordsFigure)
        {
            int dx = Math.Abs(coordsKnight[0] - coordsFigure[0]);
            int dy = Math.Abs(coordsKnight[1] - coordsFigure[1]);
            return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты коня x1, y1, и координаты фигуры x2, y2");
            string? input = Console.ReadLine()?.ToLower();


            if (!string.IsNullOrEmpty(input))
            {
                string[] inputParts = input.Split(' ');
                if (inputParts.Length == 2)
                {
                    string coordsKnight = inputParts[0];
                    string coordsFigure = inputParts[1];

                    if (CheckCoords(coordsKnight) && CheckCoords(coordsFigure))
                    {

                        if (CheckOneMove(coordsKnight, coordsFigure))
                        {
                            Console.WriteLine("Конь сможет побить фигуру");
                        }
                        else
                        {
                            Console.WriteLine("Конь не сможет побить фигуру");
                        }
                    }
                    else
                    {
                        ErrorOutput();
                    }
                }
                else
                {
                    ErrorOutput();
                }
            }
            else
            {
                ErrorOutput();
            }
        }
    }
}