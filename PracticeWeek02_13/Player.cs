using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWeek02_13
{
    class Player
    {
        public int X;
        public int Y;

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }

    class Chicken: Player
    {

    }

    class Fox: Player
    {

    }
}
