using System.ComponentModel.Design;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake";
            Console.CursorVisible = false;
            Menu:
            bool menu = true;
            while (menu)
            {
                         
                Start start = new Start();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Q)
                    {
                        Console.Clear();
                        bool gameloop = true;

                        double speed = 1000 / 5.0;
                        DateTime lastDate = DateTime.Now;
                        Score score = new Score();


                        for (int i = 0; i < 25; i++)
                        {
                            Coordinate coordinateframe = new Coordinate();
                            coordinateframe.FrameCoordinate("|", 0, i);
                            coordinateframe.FrameCoordinate("|", 132, i);

                        }
                        for (int j = 1; j < 132; j++)
                        {
                            Coordinate coordinateframe = new Coordinate();
                            coordinateframe.FrameCoordinate("-", j, 0);
                            coordinateframe.FrameCoordinate("-", j, 24);
                        }


                        Meal meal = new Meal();

                        Snake snake = new Snake();

                        while (gameloop)
                        {
                            Coordinate coordinatescore = new Coordinate(55, 25);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            string info = "Your score now: ";
                            coordinatescore.Draw();
                            Console.WriteLine(info + score.score);
                            Console.ResetColor();

                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo input = Console.ReadKey();
                                switch (input.Key)
                                {
                                    case ConsoleKey.RightArrow:
                                        snake.Direction = Direction.Right;
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        snake.Direction = Direction.Left;
                                        break;
                                    case ConsoleKey.UpArrow:
                                        snake.Direction = Direction.Up;
                                        break;
                                    case ConsoleKey.DownArrow:
                                        snake.Direction = Direction.Down;
                                        break;
                                }
                            }

                            if ((DateTime.Now - lastDate).TotalMilliseconds >= speed)
                            {

                                snake.Move();
                                if (snake.HeadPosition.X == meal.coordinate.X && snake.HeadPosition.Y == meal.coordinate.Y)
                                {
                                    score.score = score.AddPoint();
                                    snake.EatMeal();
                                    meal = new Meal();
                                    speed /= 1.1;

                                }
                                if (snake.GameOver || snake.GameOverFrame)
                                {
                                    Console.Clear();
                                    Coordinate coordinateMenu = new Coordinate();

                                    coordinateMenu.Draw(55, 6);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("GameOver");
                                    Console.ResetColor();

                                    gameloop = false;
                                    score.SaveScore(score.score);

                                    
                                    coordinateMenu.Draw(60, 9);
                                    MenuBack menuback = new MenuBack();
                                    if(menuback.menuControl == true) { goto Menu; }
                                }
                                lastDate = DateTime.Now;
                            }

                        }
                    }
                    else if (key.Key == ConsoleKey.W)
                    {
                        menu = false;
                        Console.Clear();
                        Score score = new Score();
                        Coordinate coordinateMenu = new Coordinate();
                        score.LoadScore();
                        coordinateMenu.Draw(60, score.i);
                        MenuBack menuback = new MenuBack();
                        if (menuback.menuControl == true) { goto Menu; }
                      
                    }
                    else if (key.Key == ConsoleKey.E)
                    {
                        menu = false;
                        Console.Clear();
                        Coordinate coordinateMenu = new Coordinate();
                        Tutorial tutorial = new Tutorial();
                        coordinateMenu.Draw(60, 14);
                        MenuBack menuback = new MenuBack();
                        if (menuback.menuControl == true) { goto Menu; }


                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        menu = false;
                        Console.Clear();
                    }
                    else if (key.Key == ConsoleKey.R)
                    {
                        menu = false;
                        Console.Clear();

                        Coordinate coordinateMenu = new Coordinate();
                        Score score = new Score();
                        coordinateMenu.Draw(40, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("If u are sure (click e) to delete your score:");
                        Console.ResetColor();
                        coordinateMenu.Draw(40, 12);
                        score.DeleteScore();
                        coordinateMenu.Draw(40, 14);
                        MenuBack menuback = new MenuBack();
                        if (menuback.menuControl == true) { goto Menu; }
                        
                        
                    }
                }


            }

        }
    }
}