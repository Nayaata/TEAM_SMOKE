//The first team project.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace PingPong
{
    class PingPong
    {
        static char symbolPaddle = '=';
        static int PaddleLength = 10;
        static int PaddlePositionX = Console.WindowWidth / 2 - PaddleLength / 2;
        static int PaddlePositionY = Console.WindowHeight - 1;
        static void PrintPossition(int x, int y, char symbolPaddle, int length)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(symbolPaddle, length));
        }
        static void ConsoleParameters()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
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
        static void Main()
        {
            ConsoleParameters();
            MovePaddle();
        }
    }
}
