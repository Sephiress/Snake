using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Coordinate
    {
        public Coordinate()
        {
            X= 0;
            Y= 0;   
        }  
        public int X { get; set; }
        public int Y { get; set; }
       public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void FrameCoordinate(string draw, int x = 0, int y = 0)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(draw);
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            
        }
        public void Draw(int x, int y)
        {
            X = x;  
            Y = y;  
            Console.SetCursorPosition(X, Y);

        }
    }
}
