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
        
        static void Logo(int posX, int posY)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            char[,] matrix ={   {' ', ' ', ' ', '§', ' ', ' ', ' ', ' '},                        
                                {' ', ' ', '§', ' ', '§', ' ', ' ', ' '},
                                {' ', '§', ' ', ' ', ' ', '§', ' ', ' '},
                                {' ', ' ', '§', ' ', ' ', '§', '§', ' '},
                                {' ', ' ', ' ', '§', ' ', ' ', '§', '§'},
                                {' ', ' ', '§', '§', ' ', ' ', ' ', '§'},
                                {' ', ' ', ' ', '§', ' ', ' ', '§', ' '},
                                {' ', ' ', ' ', ' ', '§', ' ', '§', ' '},
                                {' ', ' ', ' ', ' ', ' ', '§', ' ', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', ' ', ' ', ' ', ' ', '*', ' ', ' '},
                                {' ', ' ', ' ', ' ', ' ', '*', '*', ' '},
                                {' ', ' ', ' ', '*', '*', 'X', 'X', '*'},
                                {' ', ' ', '*', '$', '$', 'X', 'X', '*'},
                                {' ', '*', '$', 'X', 'X', 'X', '*', ' '},
                                {'*', '$', 'X', '$', '$', 'X', '$', '*'},
                                {'*', '$', 'X', '$', '$', 'X', '$', '*'},
                                {' ', '*', '$', 'X', 'X', '$', '*', ' '},
                                {' ', ' ', '*', '$', '$', '*', ' ', ' '},
                                {'-', '-', '-', '-', '-', '-', '-', '-'},
                                {'\\','S', 'M', 'O', 'K', 'E', '\u00AE', '/'},
                                {' ', '\\', '_', '_', '_', '_', '/', ' '},

                           };
            int tmp = 0;
            while (tmp<5)
            {
                tmp++;
                Console.SetCursorPosition(posX, posY + 11);
                for (int i = 9; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (matrix[i, j] == '-' || matrix[i, j] == '_' || matrix[i, j] == '\\' || matrix[i, j] == '/')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(matrix[i, j]);
                    }
                    Console.SetCursorPosition(posX, posY + i +2);
                }


                Console.SetCursorPosition(posX, posY + 9);
                for (int i = 8; i >= 0; i--)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
   
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(matrix[i, j]);                
                    }
                    Console.SetCursorPosition(posX, posY + i);
                    Thread.Sleep(150);
                }
                Console.Clear();
            }
            Console.SetCursorPosition(0, 0);
        }   // Nikk-Dzhurov
    

        static void ConsoleView() //Niya Keranova
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
           
            int height = Console.BufferHeight;
            int width = Console.BufferWidth;
            for (int i = 0; i < width; i++)
            {
                Console.Write("_");
            }
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("-|");
                Console.SetCursorPosition(width - 2, i);
                Console.Write("|-");
                Console.SetCursorPosition(0, i);
            }

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            char symbol = '\u00AF';
            for (int i = 0; i < width; i++)
            {
                Console.Write(symbol);
            }
        }

        static void Startup() //Niya Keranova
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string title = "PING-PONG GAME";
            Console.CursorLeft = Console.BufferWidth / 2 - title.Length / 2;
            Console.WriteLine(title);
            
            string longestString = "Rightarow (->) - Right";
            int cursorLeft = Console.BufferWidth - longestString.Length * 2 - 10;

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
        static void Greatings() //Niya Keranova
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string greatings = "TEAM SMOKE: PING-PONG GAME";
            int y = Console.WindowHeight / 2;
            int x = (Console.WindowWidth / 2 + 10) - greatings.Length;
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < greatings.Length; i++)
            {
                Console.Write(greatings[i]);
                Thread.Sleep(100);
            }
            Thread.Sleep(1500);
        }
        static void Loading() //Niya Keranova
        {
            int i = 0;
            while (i != 8)
            {
                Console.WriteLine("Loading : (|)");
                Thread.Sleep(50);
                Console.Clear();
                Console.WriteLine("Loading : (/)");
                Thread.Sleep(50);
                Console.Clear();
                Console.WriteLine("Loading : (~)");
                Thread.Sleep(50);
                Console.Clear();
                Console.WriteLine("Loading : (\\)");
                Thread.Sleep(50);
                Console.Clear();
                i++;
            }
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
            Console.BufferHeight = Console.WindowHeight = 35; //Niya Keranova
            Console.BufferWidth = Console.WindowWidth = 90;   //Niya Keranova
            Console.Title = "TEAM SMOKE - PING-PONG GAME";   // Nikk-Dzhurov
            Logo(40, 5);    // Nikk-Dzhurov
            Greatings();    //Niya Keranova
            Loading();      //Niya Keranova
            Startup();      //Niya Keranova
            Loading();      //Niya Keranova
            ConsoleView();  //Niya Keranova
            database = new Dictionary<string, int>(); // Todor Dimitrov
            LoadResults(); // Todor Dimitrov
            RegisterPlayer(); // Todor Dimitrov
            Console.CursorVisible = false;   
            MovePaddle(); // Nicola
        }
    }
}
