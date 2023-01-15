using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    internal class Score
    {
        public int score { get; set; }
        public Score() 
        {
            score = 0;
        }
        public int AddPoint()
        {
            score++;
            return score;
        }

        public void SaveScore(int score)
        {
            StreamWriter file = new StreamWriter("../../../score.txt", true);
            DateTime DateScore = DateTime.Now;
            string month = DateScore.Month.ToString();
            #region Month
            switch (DateScore.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;

            }
            #endregion
            file.WriteLine(DateScore.Day.ToString() + " " + month + " "+ DateScore.Year.ToString() + ": " +score.ToString()); 
            file.Close();
        }
        public int i { get; set; }
        public bool menuControl { get; set; }
        public void DeleteScore()
        {
            bool menuControl = true;
            while (menuControl)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyMenu = Console.ReadKey();
                    if (keyMenu.Key == ConsoleKey.E)
                    {
                        menuControl = false;
                        this.menuControl = true;
                    }
                }
            }
            if(this.menuControl == true)
            {
                string path = @"../../../score.txt";
                File.Delete(path);
                Console.WriteLine("xactly, your score deleted");
            }

        }
        public void LoadScore() 
        {

            try
            {
                StreamReader file = new StreamReader("../../../score.txt");
                int i = 9;
                Coordinate filePosition = new Coordinate();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                filePosition.Draw(60, 7);
                Console.WriteLine("Your Score:");
                Console.ResetColor();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    filePosition.Draw(55, i);
                    Console.WriteLine(line);
                    i++;
                    this.i = i;
                }
                file.Close();
            }
            catch(Exception) 
            {
                i = 12;
                Coordinate filePosition = new Coordinate();
                filePosition.Draw(50, 7);
                Console.WriteLine("You dont have any score");
            }
        }
    }
}
