using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Tutorial
    {
        public Tutorial() 
        {
            Coordinate tutorial = new Coordinate();
            tutorial.Draw(40, 7);
            Console.WriteLine("How can I control my snake?");
            tutorial.Draw(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Its simple. Use keys with arrow on your keyboard to make a move.");
            Console.ResetColor();
        }
    }
}
