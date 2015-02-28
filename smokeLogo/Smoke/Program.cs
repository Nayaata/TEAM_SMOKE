using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Logo(0,0);
        }
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
            
            while (true)
            {
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
        }
    }
}
