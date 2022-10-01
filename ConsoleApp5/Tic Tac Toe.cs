using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;


        /// <summary>
        /// This Function Draws the Board on The Console
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("      |     |     ");
            Console.WriteLine("  {0}   |  {1}  |  {2} ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("______|_____|_____");
            Console.WriteLine("      |     |     ");
            Console.WriteLine("  {0}   |  {1}  |  {2} ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("______|_____|_____");
            Console.WriteLine("      |     |     ");
            Console.WriteLine("  {0}   |  {1}  |  {2} ",spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("      |     |     ");
        }

        /// <summary>
        /// Check if the game is won, Tied , or Should Continue 
        /// </summary>
        /// <param name="args"></param>
        static int CheckWin()
        {
            if (spaces[0] == spaces[1] && spaces[1] == spaces[2] //row 1
                ||
                spaces[3] == spaces[4] && spaces[4] == spaces[5] //row 2
                ||
                spaces[6] == spaces[7] && spaces[7] == spaces[8] //row 3
                ||
                spaces[0] == spaces[3] && spaces[3] == spaces[6] //column 1
                ||
                spaces[1] == spaces[4] && spaces[4] == spaces[7] //column 2
                ||
                spaces[2] == spaces[5] && spaces[5] == spaces[8] //column 3
                ||
                spaces[0] == spaces[4] && spaces[4] == spaces[8] //diagonal 1
                ||
                spaces[2] == spaces[4] && spaces[4] == spaces[6] //diagonal 2
                ) 
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                     spaces[1] != '2' &&
                     spaces[2] != '3' &&
                     spaces[3] != '4' &&
                     spaces[4] != '5' &&
                     spaces[5] != '6' &&
                     spaces[6] != '7' &&
                     spaces[7] != '8' &&
                     spaces[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Draw X on the Board 
        /// </summary>
        /// <param name="args"></param>
        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }


        /// <summary>
        /// Draw O on the Board 
        /// </summary>
        /// <param name="args"></param>
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }


        /// <summary>
        /// The Main Game Loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(50, 20);
                        


            do
            {
                Console.Clear();    
                Console.WriteLine("Player 1 : X AND Player 2 : O");
                if (player % 2 == 0) 
                {
                    Console.WriteLine("Player 2's Turn");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn");
                }

                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1 ;

                if (spaces[choice] != 'X' &&
                    spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already Marked with {1} \n ",
                                        choice, spaces[choice]);
                    Console.WriteLine("Please Wait 1 Second Board Is Loading Again..");
                    Thread.Sleep(1000);
                }

                flag = CheckWin();


            } while (flag != 1 && flag !=  -1 );

            Console.Clear();
            DrawBoard();

            if( flag == 1 )
            {
                Console.WriteLine("Player {0} has won ", (player % 2 ) + 1 );
            }
            else
            {
                Console.WriteLine("Tie Game");
            }

            Console.ReadLine();

        }
    }
}
