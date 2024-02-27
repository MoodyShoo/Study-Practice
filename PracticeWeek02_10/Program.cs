/*
 * Поле шахматной доски определяется парой символов состоящей из буквы от a до h, и цифры от 1 до 8. 
 * С помощью датчика случайных значений получить координаты двух полей. 
 * Координаты полей должны быть такими, что:
 *     если на поле x1y1 расположена ладья, то она не угрожает полю x2y2;
 *     если на поле x1y1 расположен слон, то он не угрожает полю x2y2;
 *     если на поле x1y1 расположен король, то он может одним ходом попасть на поле x2y2;
 *     если на поле x1y1 расположен ферзь, то он не угрожает полю x2y2
 * В качестве входных данных указывается название фигуры, расположенной на поле x1y1
 */

namespace Task_10
{
    class Program
    {
        static Random rand = new Random();
        static void changeFieldCoords(ref int fieldX, ref char fieldY)
        {
            fieldX = rand.Next(1, 9);
            fieldY = (char)rand.Next('a', 'i');
        }

        static void ChooseFigure(ref string figure, ref int figureX, ref char figureY, ref int fieldX, ref char fieldY)
        {
            switch (figure)
            {
                case "ладья":
                    do
                    {
                        changeFieldCoords(ref fieldX, ref fieldY);

                    } while (figureX == fieldX || figureY == fieldY);
                    break;

                case "слон":
                    do
                    {
                        changeFieldCoords(ref fieldX, ref fieldY);

                    } while (Math.Abs(figureX - fieldX) == Math.Abs(figureY - fieldY));
                    break;

                case "король":
                    do
                    {
                        changeFieldCoords(ref fieldX, ref fieldY);

                    } while (Math.Abs(figureX - fieldX) > 1 || Math.Abs(figureY - fieldY) > 1);
                    break;

                case "ферзь":
                    do
                    {
                        changeFieldCoords(ref fieldX, ref fieldY);

                    } while ((figureX == fieldX || figureY == fieldY) || Math.Abs(figureX - fieldX) == Math.Abs(figureY - fieldY));
                    break;
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите название фигуры");
            string? figure = Console.ReadLine();
            int figureX = rand.Next(1, 9);
            char figureY = (char)rand.Next('a', 'i');

            int fieldX = 0;
            char fieldY = ' ';

            ChooseFigure(ref figure, ref figureX, ref figureY, ref fieldX, ref fieldY);

            Console.WriteLine($"Фигура {figure} стоит на поле {figureY}{figureX}. Второе поле {fieldY}{fieldX}");
        }
    }
}