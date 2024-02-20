/* 
 * Задача 4
 * Даны координаты нахождения короля на шахматной доске. 
 * Требуется определить, бьет ли король фигуру, стоящую на другой указанной клетке за один ход. 
 * Координаты короля и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
 * В качестве выходного сообщения выводится одна из строк: "Король сможет побить фигуру", "Король не сможет побить фигуру", "Введены некорректные координаты"
 */

using System.IO;

namespace Task_04
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

        static bool CheckOneMove(string coordsKing, string coordsFigure)
        {
            return (Math.Abs(coordsKing[0] - coordsFigure[0]) <= 1 && Math.Abs(coordsKing[1] - coordsFigure[1]) <= 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты короля x1, y1, и координаты фигуры x2, y2");
            string? input = Console.ReadLine()?.ToLower();


            if (!string.IsNullOrEmpty(input))
            {
                string[] inputParts = input.Split(' ');
                if (inputParts.Length == 2)
                {
                    string coordsKing = inputParts[0];
                    string coordsFigure = inputParts[1];

                    if (CheckCoords(coordsKing) && CheckCoords(coordsFigure))
                    {

                        if (CheckOneMove(coordsKing, coordsFigure))
                        {
                            Console.WriteLine("Король сможет побить фигуру");
                        }
                        else
                        {
                            Console.WriteLine("Король не сможет побить фигуру");
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