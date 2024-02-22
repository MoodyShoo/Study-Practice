namespace Task_08
{
    class Program
    {
        static bool CheckCoords(string coords1, string coords2)
        {
            return (coords1[0] + coords1[1] % 2 == coords2[0] + coords2[1] % 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты клетки x1, y1, и координаты клетки x2, y2");
            string input = Console.ReadLine().ToLower();
            string[] inputParts = input.Split(' ');

            string coordsOne = inputParts[0];
            string coordsTwo = inputParts[1];

            if (CheckCoords(coordsOne, coordsTwo))
            {
                Console.WriteLine("Поля являются полями одного цвета");
            } 
            else 
            {
                Console.WriteLine("Поля не являются полями одного цвета");
            }

        }
    }
}