/*
 * Задача 2
 * Даны координаты нахождения слона на шахматной доске. 
 * Требуется определить, бьет ли слон фигуру, стоящую на другой указанной клетке за один ход. 
 * Координаты слона и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
 * В качестве выходного сообщения выводится одна из строк: "Слон сможет побить фигуру", "Слон не сможет побить фигуру", "Введены некорректные координаты"
 */

using System.IO;

namespace Task_01
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

        static bool CheckOneMove(string coordsRook, string coordsFigure)
        {
            return (Math.Abs(coordsRook[0] - coordsFigure[0])) == Math.Abs(coordsRook[1] - coordsFigure[1]);
        }

        static void Main(string[] args)
        {
            string? input = Console.ReadLine()?.ToLower();


            if (!string.IsNullOrEmpty(input))
            {
                string[] inputParts = input.Split(' ');
                if (inputParts.Length == 2)
                {
                    string coordsRook = inputParts[0];
                    string coordsFigure = inputParts[1];

                    if (CheckCoords(coordsRook) && CheckCoords(coordsFigure))
                    {

                        if (CheckOneMove(coordsRook, coordsFigure))
                        {
                            Console.WriteLine("Слон сможет побить фигуру");
                        }
                        else
                        {
                            Console.WriteLine("Слон не сможет побить фигуру");
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