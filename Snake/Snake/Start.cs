using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Start
    {
        public Start()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Coordinate start = new Coordinate();
            start.Draw(60,7);
            Console.WriteLine("Snake");
            Console.ForegroundColor = ConsoleColor.White;
            start.Draw(55,9);
            Console.WriteLine("Start (click q)");
            start.Draw(55,11);
            Console.WriteLine("Score (click w)");
            start.Draw(55,13);
            Console.WriteLine("Control keys (click e)");
            start.Draw(55, 15);
            Console.WriteLine("Delete score (click r)");
            start.Draw(55, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exit (click esc)");

            Console.ResetColor();
        }



    }
}
