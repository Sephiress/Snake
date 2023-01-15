using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Meal
    {
        public Meal() 
        {
            Random rndY = new Random();
            Random rndX = new Random();
            int x = rndX.Next(1, 131);
            int y = rndY.Next(1, 24);
            if ((x == 0 || x == 132 && y <= 24) || (y == 0 || y == 24 && x <= 131))
            {
                x = rndX.Next(1, 24);
                y = rndY.Next(1, 131);
            }
            coordinate = new Coordinate(x, y);
            RandomMeal();
        }

        public void RandomMeal()
        {

            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");

        }
        public Coordinate coordinate { get; set; }
    }
}
