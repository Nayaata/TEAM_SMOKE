//The first team project.
namespace PingPong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Media;
    
        class PingPong
        {
            private static Dictionary<string, int> database; // Todor Dimitrov
            private static string currentUsername; // Todor Dimitrov
            static int width = 70;
            static int height = 45;
            static ConsoleColor ColorOfPaddle = ConsoleColor.White;
            static char symbolPaddle = '_';
            static char symbolPaddle2 = '*';
            static int PaddleLength = 20;
            static int PaddlePositionX = width / 2 - PaddleLength / 2;
            static int PaddlePositionY = height - 4;
            static int BallPosX = width / 2 - 5;
            static int BallPosY = height / 2 + 5;
            static int BallPosX2 = width / 2 ;
            static int BallPosY2 = height / 2 ;
            static bool BallDirectionUp = true;
            static bool BallDirectionUp2 = true;
            static bool BallDirectionRight = true;
            static bool BallDirectionRight2 = true;
            static int points = 0;
            static int levels = 1;
            
            private static void MoveBall() // Nikk-Dzhurov
            {
                if (BallPosX == Console.WindowWidth - 4)
                {
                    SoundOfInpactWall();
                    BallDirectionRight = false;
                }
                if (BallPosX == 2)
                {
                    SoundOfInpactWall();
                    BallDirectionRight = true;
                }
                if (BallPosY == 1)
                {
                    SoundOfInpactWall();
                    BallDirectionUp = false;
                }
                if (BallPosY == Console.WindowHeight - 3)
                {
                    SoundOfInpactWall();
                    BallDirectionUp = true;
                }
                if (BallDirectionUp)
                {
                    BallPosY--;
                }
                else
                {
                    BallPosY++;
                    
                }
                if (BallDirectionRight)
                {
                    BallPosX++;
                }
                else
                {
                    BallPosX--;
                }
            }
    
            static void MoveBall2() // Peter Boev
            {
                if (BallPosX2 == Console.WindowWidth - 4)
                {
                    SoundOfInpactWall();
                    BallDirectionRight2 = false;
                }
                if (BallPosX2 == 2)
                {
                    SoundOfInpactWall();
                    BallDirectionRight2 = true;
                }
                if (BallPosY2 == 1)
                {
                    SoundOfInpactWall();
                    BallDirectionUp2 = false;
                }
                if (BallPosY2 == Console.WindowHeight - 3)
                {
                    SoundOfInpactWall();
                    BallDirectionUp2 = true;
                }
                if (BallDirectionUp2)
                {
                    BallPosY2--;
                }
                else
                {
                    BallPosY2++;         
                }
                if (BallDirectionRight2)
                {
                    BallPosX2++;
                }
                else
                {
                    BallPosX2--;
                }
    
            }
    
            static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color) // Nikk-Dzhurov
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(symbol);
            }
            
            static void Logo(int posX, int posY) // Nikk-Dzhurov
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.CursorVisible = false;
                char[,] matrix ={ {' ', ' ', ' ', '§', ' ', ' ', ' ', ' '},
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
                                  {' ', '\\', '_', '_', '_', '_', '/', ' '}, };
                int tmp = 0;
                while (tmp < 5)
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
                        Console.SetCursorPosition(posX, posY + i + 2);
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
            }
            
            static void ConsoleView() //Niya Keranova
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
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
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string title = "PING-PONG GAME";
                Console.CursorLeft = Console.BufferWidth / 2 - title.Length / 2;
                Console.WriteLine(title);
                string longestString = "Rightarow (->) - Right";
                int cursorLeft = Console.BufferWidth - longestString.Length * 2 - 1;
                Console.CursorTop = 5;
                Console.CursorLeft = cursorLeft;
                string oneRow = "Player's controls:";
                Console.WriteLine(oneRow);
                Console.ForegroundColor = ConsoleColor.Green;
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
                Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                while (i != 7)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
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
            
            static void PrintPaddlePossition(int x, int y, char symbolPaddle, int length, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(new string(symbolPaddle2, length));
                Console.SetCursorPosition(x, y - 1);
                Console.Write(new string(symbolPaddle, length));
            }
            
            static void ClearBox() // Nikk-Dzhurov
            {
                for (int i = 1; i < Console.WindowHeight - 2; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, i);
                    Console.Write(new string(' ', Console.WindowWidth - 4));
                }
            }
            
            static void PlayerMoveLeft(int padPositionX)
            {
                if (PaddlePositionX < Console.WindowWidth - PaddleLength - 2)
                {
                    PaddlePositionX++;
                }
                PrintPaddlePossition(PaddlePositionX, PaddlePositionY, symbolPaddle, PaddleLength, ColorOfPaddle);
            }
            
            static void PlayerMoveRigth(int padPositionX)
            {
                if (PaddlePositionX > 2)
                {
                    PaddlePositionX--;
                }
                PrintPaddlePossition(PaddlePositionX, PaddlePositionY, symbolPaddle, PaddleLength, ColorOfPaddle);
            }
            
            static void MovePaddle()
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        PlayerMoveLeft(PaddlePositionX + 2);
                    }
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        PlayerMoveRigth(PaddlePositionX + 2);
                    }
                }
            }
            
            private static void RegisterPlayer() // Todor Dimitrov
            {
                do
                {
                    Console.Write("Enter your username: ");
                    currentUsername = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(currentUsername));
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
            
            private static void SoundOfInpactWall()                                       // Chernogorov
            {
                SoundPlayer soundWall = new SoundPlayer();                                // Chernogorov
                soundWall.SoundLocation = @"..\\..\\..\\soundWall.wav";                   // Chernogorov
                soundWall.Play();                                                         // Chernogorov
            }
            
            private static void SoundOfGameNewLive()                                      // Chernogorov
            {
                SoundPlayer soundLive = new SoundPlayer();                              // Chernogorov
                soundLive.SoundLocation = @"..\\..\\..\\newLive.wav";                   // Chernogorov
                soundLive.Play();                                                       // Chernogorov
            }
            
            private static void SoundOfGameOver()                                       // Chernogorov
            {
                SoundPlayer soundGameOver = new SoundPlayer();                          // Chernogorov
                soundGameOver.SoundLocation = @"..\\..\\..\\gameOver.wav";              // Chernogorov
                soundGameOver.Play();                                                   // Chernogorov
                Thread.Sleep(300);
                
            }
            
            private static void SoundOfJumpBall()                                       //Chernogorov
            {
                SoundPlayer soundJumpBall = new SoundPlayer();                          // Chernogorov
                soundJumpBall.SoundLocation = @"..\\..\\..\\jumpBall.wav";              // Chernogorov
                soundJumpBall.Play();                                                   // Chernogorov
            }
            
            private static void ChoiceMenu()                                           //Chernogorov
            {
                
                if (BallPosY > PaddlePositionY || BallPosY2 > PaddlePositionY)                               //Chernogorov
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition((Console.WindowWidth - 23) / 2 , Console.WindowHeight - 20);   //Chernogorov
                    Console.WriteLine("Press key 'A' for new Game!");                                        //Chernogorov
                    Console.SetCursorPosition((Console.WindowWidth - 2) / 2, Console.WindowHeight - 18);     //Chernogorov
                    Console.WriteLine("OR");                                                                 //Chernogorov
                    Console.SetCursorPosition((Console.WindowWidth - 23) / 2, Console.WindowHeight - 16);    //Chernogorov
                    Console.WriteLine("Press key 'S' for list result!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition((Console.WindowWidth - 23) / 2, Console.WindowHeight - 33); //Chernogorov
                    ConsoleKeyInfo keyOne = Console.ReadKey();                                               //Chernogorov
                    if (keyOne.KeyChar == 'a')                                                               //Chernogorov
                    {
                        Console.Clear();                                                                     //Chernogorov
                        Main();                                                                              //Chernogorov
                    }
                    if (keyOne.KeyChar == 's')                                                               //TodorDimitrov
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        var results = database.OrderByDescending(p => p.Value).ToDictionary(k => k.Key,k => k.Value);
                        Console.WriteLine("Results".PadLeft((Console.WindowWidth / 2) - 7,' '));
                        Console.WriteLine();
                        foreach (var player in results)
                        {
                            string name = player.Key;
                            string score = player.Value.ToString().PadLeft(Console.WindowWidth - name.Length, '-');
                            Console.WriteLine("{0}{1}",name,score);
                        }
                        Console.WriteLine();
                        Console.CursorVisible = false;
                    }
                    if (keyOne.KeyChar != 's' && keyOne.KeyChar != 'a')
                    {
                        ChoiceMenu();
                    }
    
                }
            }
    
            static void PrintPoints() // Peter Boev
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 0);
                Console.Write("Points : {0}", points);
            }
            
            static void PrintLevel() // Peter Boev
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 6, 0);
                Console.Write("Level : {0}", levels);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(width - 20, height - 1);
            }
            
            static void PrindSecondBall() // Peter Boev
            {
                PrintAtPosition(BallPosX2, BallPosY2, '\u00A9', ConsoleColor.Red);
            }
            
            static void Main()
            {
                PaddlePositionX = width / 2 - PaddleLength / 2;
                PaddlePositionY = height - 4;
                BallPosX = width / 2 - 5;
                BallPosY = height / 2 + 5;
                BallPosX2 = width / 2;
                BallPosY2 = height / 2;
                BallDirectionUp = true;
                BallDirectionUp2 = true;
                points = 0;
                levels = 1;
    
                int stateOfColor = 1;
                ConsoleColor[] colours = { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Red };
                Console.BufferHeight = Console.WindowHeight = 45; //Niya Keranova
                Console.BufferWidth = Console.WindowWidth = 70; //Niya Keranova
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Title = "TEAM SMOKE - PING-PONG GAME"; // Nikk-Dzhurov
                Logo((Console.WindowWidth - 8) / 2, (Console.WindowHeight - 22) / 2); // Nikk-Dzhurov
                Greatings(); //Niya Keranova
                Loading(); //Niya Keranova
                Startup(); //Niya Keranova
                Loading(); //Niya Keranova
                database = new Dictionary<string, int>(); // Todor Dimitrov
                LoadResults(); // Todor Dimitrov
                RegisterPlayer(); // Todor Dimitrov
                Console.CursorVisible = false;
                ConsoleView(); //Niya Keranova            
                Console.ForegroundColor = ConsoleColor.Red; // Nikk-Dzhurov
                Console.BackgroundColor = ConsoleColor.Black; // Nikk-Dzhurov
                PrintPaddlePossition(PaddlePositionX, PaddlePositionY, symbolPaddle, PaddleLength, ColorOfPaddle); // Nikk-Dzhurov
                PrintAtPosition(BallPosX, BallPosY, '\u00A9', ConsoleColor.Green); // Nikk-Dzhurov
                Console.SetCursorPosition((Console.WindowWidth - 23) / 2, Console.WindowHeight / 2); // Nikk-Dzhurov
                Console.Write("Press any key to start!"); // Nikk-Dzhurov
                Console.ReadKey();
                while (true)
                {
                    PrintPoints(); // Peter Boev
                    PrintLevel(); // Peter Boev
                    MoveBall(); // Nicola
                    if (points > 4) { levels = 2; MoveBall2(); } //Peter Boev
                    MovePaddle(); // Nicola
                    while (Console.KeyAvailable)
                        Console.ReadKey(true);
                    ClearBox(); // Nikk-Dzhurov
                    PrintPaddlePossition(PaddlePositionX, PaddlePositionY, symbolPaddle, PaddleLength, ColorOfPaddle); // Nikk-Dzhurov
                    PrintAtPosition(BallPosX, BallPosY, '\u00A9', ConsoleColor.Green); // Nikk-Dzhurov
                    if (points > 4) // Peter Boev
                    {
                        PrindSecondBall();                    
                    }
                    if (BallPosY == PaddlePositionY - 1 ) // Nikk-Dzhurov
                    { 
                        if (BallPosX >= PaddlePositionX && BallPosX <= PaddlePositionX + PaddleLength) 
                        { 
                            points++; // Peter Boev
                            ColorOfPaddle = colours[stateOfColor++];
                            SoundOfJumpBall(); // Chernogorov
                            if (stateOfColor > 2) 
                            { 
                                stateOfColor = 0; 
                            } 
                            BallDirectionUp = true; 
                        } 
                    }
                    if (BallPosY2 == PaddlePositionY - 1) // Peter Boev
                    {
                        if (BallPosX2 >= PaddlePositionX && BallPosX2 <= PaddlePositionX + PaddleLength)
                        {
                            points++; 
                            ColorOfPaddle = colours[stateOfColor++];
                            SoundOfJumpBall(); // Chernogorov
                            if (stateOfColor > 2)
                            {
                                stateOfColor = 0;
                            }
                            BallDirectionUp2 = true;
                        }
                    } 
                    if (BallPosY > PaddlePositionY || BallPosY2 > PaddlePositionY) // Nikk-Dzhurov
                    { // Nikk-Dzhurov
                        if (database[currentUsername] < points)
                        {
                            database[currentUsername] = points;
                            SaveChanges();
                        }
                        Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.WindowHeight / 2); // Nikk-Dzhurov
                        Console.Write("Game Over!"); // Nikk-Dzhurov
                        SoundOfGameOver(); // Chernogorov   
                        ChoiceMenu();// Chernogorov
                        Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2 + 2); // Nikk-Dzhurov
                        break; // Nikk-Dzhurov
                    }
                    Thread.Sleep(30);
                }
            }
        }
    }
