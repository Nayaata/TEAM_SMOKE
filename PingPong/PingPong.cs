//The first team project.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace PingPong
{
    class PingPong
    {
        private static Dictionary<string, int> database; // Todor Dimitrov
        private static string currentUsername; // Todor Dimitrov
        static void ConsoleView()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 100;

           
        }

        static void StartupScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string title = "PING-PONG GAME";
            Console.CursorLeft = Console.BufferWidth / 2 - title.Length / 2;
            Console.WriteLine(title);

            string longestString = "Rightarow (->) - Right";
            int cursorLeft = Console.BufferWidth - longestString.Length * 2 - 5;

            Console.CursorTop = 5;
            Console.CursorLeft = cursorLeft;
            string oneRow = "Player's controls:";
            Console.WriteLine(oneRow);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = cursorLeft;
            string twoRow = "Leftarow (<-) - Left";
            Console.WriteLine(twoRow);
            Console.CursorLeft = cursorLeft;
            string threeRow = "Rightarow (->) - Right";
            Console.WriteLine(threeRow);

            Console.ReadKey();
            Console.Clear();
        }

        static char symbolPaddle = '=';
        static int PaddleLength = 10;
        static int PaddlePositionX = Console.WindowWidth / 2 - PaddleLength / 2;
        static int PaddlePositionY = Console.WindowHeight + 3;
        static void PrintPossition(int x, int y, char symbolPaddle, int length)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(symbolPaddle, length));
        }

        static int PlayerMoveLeft(int padPositionX)
        {
            if (PaddlePositionX < Console.WindowWidth - PaddleLength - 1)
            {
                PaddlePositionX++;
            }
            return PaddlePositionX;
        }
        static int PlayerMoveRigth(int padPositionX)
        {
            if (PaddlePositionX > 0)
            {
                PaddlePositionX--;
            }
            return PaddlePositionX;
        }
        static void MovePaddle()
        {
            while (true)
            {
                PrintPossition(PaddlePositionX, PaddlePositionY, symbolPaddle, PaddleLength);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    PrintPossition(PlayerMoveLeft(PaddlePositionX), PaddlePositionY, symbolPaddle, PaddleLength);
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    PlayerMoveRigth(PaddlePositionX);
                }
                Console.Clear();
            }
        }
        private static void RegisterPlayer() // Todor Dimitrov
        {
            Console.Write("Enter your username: ");
            currentUsername = Console.ReadLine();
            if (!database.Keys.Any(username => username == currentUsername))
            {
                database.Add(currentUsername, 0);
                SaveChanges();
            }
            Console.Clear();
        }
         private static void SaveChanges() // Todor Dimitrov
         {
             StreamWriter writer = new StreamWriter("..\\..\\..\\results.txt");
             using (writer)
             {
                 foreach (var item in database)
                 {
                     string line = String.Format("{0}-{1}", item.Key, item.Value);
                     writer.WriteLine(line);
                 }
             }
         }
         private static void LoadResults() // Todor Dimitrov
         {
             StreamReader reader = new StreamReader("..\\..\\..\\results.txt");
             using (reader)
             {
                 string line = reader.ReadLine();
                 while (line != null)
                 {
                     if (!string.IsNullOrEmpty(line))
                     {
                         string[] splitLine = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                         string username = splitLine[0];
                         int score = int.Parse(splitLine[1]);
                         database.Add(username, score);
                     }
                     line = reader.ReadLine();
                 }
             }
         }
        static void Main()
        {
                     
            database = new Dictionary<string, int>(); // Todor Dimitrov
            LoadResults(); // Todor Dimitrov
            RegisterPlayer(); // Todor Dimitrov
            Console.CursorVisible = false;   
            StartupScreen(); // Niya
            ConsoleView(); //Niya
            MovePaddle(); // Nicola
        }
    }
}
