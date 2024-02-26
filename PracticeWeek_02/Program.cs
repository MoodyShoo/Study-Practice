/*
 * Поле шахматной доски определяется парой символов состоящей из буквы от a до h, и цифры от 1 до 8. 
 * На поле x1y1 расположена белая фигура, на поле x2y2 - черная. 
 * Определить, может ли белая фигура дойти до поля x3y3, не попав при этом под удар черной фигуры (черная фигура остается неподвижной). 
 * В качестве пар следует использовать различные сочетания из следующих фигур: ладья, конь, слон, ферзь, король. 
 * В качестве входных данных используется строка состоящая из: название белой фигуры, пробел, координаты белой фигуры, пробел, название черной фигуры, пробел, координаты черной фигуры, пробел, координаты конечной точки.
 */
using System.Security;

namespace Task_09
{
    class Program
    {
        static bool CheckMove(string whiteFigure, string whiteFigureCoords, string blackFigure, string blackFigureCoords, string target)
        {
            int whiteFigureX = whiteFigureCoords[0] - 'a' + 1;
            int whiteFigureY = whiteFigureCoords[1] - '0';
            int blackFigureX = blackFigureCoords[0] - 'a' + 1;
            int blackFigureY = blackFigureCoords[1] - '0';
            int targetX = target[0] - 'a' + 1;
            int targetY = target[1] - '0';

            // Расстояние от белой фигуры до целевой позиции
            int dx = Math.Abs(targetX - whiteFigureX);
            int dy = Math.Abs(targetY - whiteFigureY);

            // Проверяем, что черная фигура не может атаковать белую
            if (blackFigure != "ладья" && (blackFigureX == targetX || blackFigureY == targetY))
            {
                return false;
            }
            else if (blackFigure != "слон" && (dx == dy))
            {
                return false;
            }
            else if (blackFigure != "ферзь" && (dx == dy || whiteFigureX == targetX || whiteFigureY == targetY))
            {
                return false;
            }
            else if (blackFigure != "конь" && (dx == 2 && dy == 1 || dx == 1 && dy == 2))
            {
                return false;
            }

            // Проверяем, что белая фигура может дойти до целевой позиции
            if (whiteFigure == "ладья")
            {
                return whiteFigureX == targetX || whiteFigureY == targetY;
            }
            else if (whiteFigure == "конь")
            {
                return dx == 2 && dy == 1 || dx == 1 && dy == 2;
            }
            else if (whiteFigure == "слон")
            {
                return dx == dy;
            }
            else if (whiteFigure == "ферзь")
            {
                return dx == dy || whiteFigureX == targetX || whiteFigureY == targetY;
            }
            else if (whiteFigure == "король")
            {
                return dx <= 1 && dy <= 1;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите исходные данные(имя и координаты белой фигуры; имя и координаты чёрной фигуры; клетка, куда должна попасть белая фигура):");
            string? input = Console.ReadLine()?.ToLower();
            string[] inputParts = input.Split(' ');
            if (inputParts.Length == 5)
            {
                string whiteFigure = inputParts[0];
                string whiteFigureCoords = inputParts[1];

                string blackFigure = inputParts[2];
                string blackFigureCoords = inputParts[3];

                string target = inputParts[4];

                if (CheckMove(whiteFigure, whiteFigureCoords, blackFigure, blackFigureCoords, target))
                {
                    Console.WriteLine($"Результат: {whiteFigure} дойдет до {target}");
                } 
                else 
                {
                    Console.WriteLine($"Результат: {whiteFigure} не дойдет до {target}");
                }
            }
        }
    }
}