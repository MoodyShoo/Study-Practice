/*
 * Задача 3
 * Даны координаты нахождения ферзя на шахматной доске. 
 * Требуется определить, бьет ли ферзь фигуру, стоящую на другой указанной клетке за один ход. 
 * Координаты ферзя и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
 * В качестве выходного сообщения выводится одна из строк: "Ферзь сможет побить фигуру", "Ферзь не сможет побить фигуру", "Введены некорректные координаты"
 */

using System.IO;

namespace Task_03
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

        static bool CheckOneMove(string coordsQueen, string coordsFigure)
        {
            return ((Math.Abs(coordsQueen[0] - coordsFigure[0])) == Math.Abs(coordsQueen[1] - coordsFigure[1]) || 
                (coordsQueen[0] == coordsFigure[0]) || (coordsQueen[1] == coordsFigure[1]));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты ферзя x1, y1, и координаты фигуры x2, y2");
            string? input = Console.ReadLine()?.ToLower();


            if (!string.IsNullOrEmpty(input))
            {
                string[] inputParts = input.Split(' ');
                if (inputParts.Length == 2)
                {
                    string coordsQueen = inputParts[0];
                    string coordsFigure = inputParts[1];

                    if (CheckCoords(coordsQueen) && CheckCoords(coordsFigure))
                    {

                        if (CheckOneMove(coordsQueen, coordsFigure))
                        {
                            Console.WriteLine("Ферзь сможет побить фигуру");
                        }
                        else
                        {
                            Console.WriteLine("Ферзь не сможет побить фигуру");
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