using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake: iSnake
    {
        public int Lenght { get; set; } = 1;

        public Direction Direction { get; set; } = Direction.Right; 
        public Coordinate HeadPosition { get; set; } = new Coordinate(55,12);

        List<Coordinate> Tail { get; set; } = new List<Coordinate>();

        private bool OutofRange = false;
 
       

        public bool GameOver
        {
            get { return (Tail.Where(a => a.X == HeadPosition.X && a.Y == HeadPosition.Y).ToList().Count > 1) || OutofRange; }
        }
        public bool GameOverFrame
        {
            get { if((HeadPosition.X == 0 || HeadPosition.X == 132 && HeadPosition.Y <= 24) 
                    || (HeadPosition.Y == 0 || HeadPosition.Y == 24 && HeadPosition.X <= 131))
                {
                    return true;
                }
                return false;  
            }
        }
        public void EatMeal()
        {
            Lenght++;
        }
        public void Move()
        {
            switch(Direction)
            { 
                 case Direction.Left:
                    HeadPosition.X--;             
                    break;

                 case Direction.Right:
                    HeadPosition.X++;          
                    break;

                 case Direction.Up:
                    HeadPosition.Y--;               
                    break;

                 case Direction.Down:
                    HeadPosition.Y++;                  
                    break;
            }
            try 
            {
                
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("#");
               
              
                Tail.Add(new Coordinate (HeadPosition.X, HeadPosition.Y));
                if(Tail.Count > Lenght)
                {
                    var tailEnd = Tail.First();
                    Console.SetCursorPosition(tailEnd.X, tailEnd.Y);
                    Console.Write(" ");
                    Tail.Remove(tailEnd);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
               OutofRange= true;
            }
        }

    }
}
