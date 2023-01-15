using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MenuBack
    {
        public bool menuControl { get; set; }
        public MenuBack()
        {
            Console.WriteLine("Back to the menu (click q)");
            bool menuControl = true;
            while (menuControl)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyMenu = Console.ReadKey();
                    if (keyMenu.Key == ConsoleKey.Q)
                    {
                        menuControl = false;
                        this.menuControl = true;
                        Console.Clear();
                    }
                }
            }

        }
    }
}

