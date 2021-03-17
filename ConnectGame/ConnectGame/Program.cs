using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    //displays the board

    public class Player //Updated by Andrie
    {

        public string Name { get; set; }
        int turn = 0;//0 for player1, 1 for player2
        public Player(string name)
        {
            Name = name;
        }

        public virtual void testInfo()
        {
            Console.WriteLine("Hello {0}", Name);
        }
        //checks turn
        //display winner
        //display turns

    }

    class Player1 : Player
    {
        //will inherit from player
        public Player1(string name) : base(name)
        {
        }

        public override void testInfo()
        {
            Console.WriteLine("Hello {0}, you'll be 'X'", Name);
        }


    }

    class Player2 : Player
    {
        //will inherit from player
        public Player2(string name) : base(name)
        {
        }

        public override void testInfo()
        {
            Console.WriteLine("Hello {0}, you'll be 'O'", Name);
        }
    }

    public class Board // Updated Lyndon
    {

        //add method to check 'bottom'
        //add method to display and update board
        //check winning combination
        // restart game

       

         public Board() {

            
         }
       

        public static void BoardDisplay(string[,] board)
        {
          Console.WriteLine("Connect 4 Game Development Project: \n");

            int i = 1;
            while (i <= 6)
            {
                Console.Write("|");
                int x = 1;
                while (x <= 7)
                {
                   
                        board[i, x] = " X ";
                        Console.Write(board[i, x]);
                             
                    x++;
                }
                i++;
                Console.Write("| \n");
            }
            Console.Write(" "+" 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 ");
        }


        
        public static void RestartBoard(string[,] board)
        {
            Console.WriteLine("Restart? Yes(1) No(0):");
            string num = Console.ReadLine();
            if (num == "1")
            {
                int i = 1;
                Console.WriteLine(" ");
                while (i <= 6)
                {
                    Console.Write("|");
                    int x = 1;
                    while (x <= 7)
                    {
                        if (board[i,x] != "X" && board[i,x] != "O")
                        {
                            board[i, x] = " # ";
                            Console.Write(board[i, x]);
                        }
                        x++;
                    }
                    i++;
                    Console.Write("| \n");
                }
                Console.Write(" " + " 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 ");
            }
            else
            {
                Console.WriteLine("Thank you for playing!");
            }
           
        }

        //public static bool WinnerBoard()
        //{

        //}
    }
    public class Controller // Updated By Andrie
    {
        //add method for the numbers(pick)
        //add method to restart
        //public void PlayerTurn()

        public static void PlayerTurn(Player activePlayer)
        {
            Console.WriteLine("Its {0}'s turn", activePlayer.Name);
        }

        //dummy code for testing
        public static void PlacePiece(char piece)
        {
            int pos;
            do
            {
                Console.WriteLine("Select a location to place a piece: ");
                pos = Convert.ToInt32(Console.ReadLine());

            } while (pos < 1 || pos > 7);

            Console.WriteLine("'{0}' placed at column {1}", piece, pos);
        }


    }


    class Program
    {
        static void Main(string[] args)
        {

            // the main

            ////initiating players
            string[,] board = new string[7, 8]; //length is 52
            string p1, p2;
            int reset = 0;
            Console.WriteLine("Enter player information: ");
            Console.Write("Player 1: ");
            p1 = Console.ReadLine();
            Console.Write("Player 2: ");
            p2 = Console.ReadLine();

            Player player1 = new Player1(p1, 'X');
            Player player2 = new Player2(p2, '0');

            player1.testInfo();
            player2.testInfo();

            Player obj = player1;
            Player obj2 = player2;

            //gameplay loop

            //display board
            Console.WriteLine("Game Start");
            do
            {
                Controller.PlayerTurn(obj);
                Controller.PlacePiece(obj.Piece);
                //display board
                //method to check bottom/win
                //if condition to display when player 1 wins 
                //display winner and ask user if they want to play again.

                Controller.PlayerTurn(obj2);
                Controller.PlacePiece(obj2.Piece);
                //display board
                //method to check bottom/win
                //if condition to display when player 1 wins 
                //display winner and ask user if they want to play again.


                //for testing and debugging
                Console.WriteLine("Reset?");
                Board.RestartBoard(board);



            } while ();


            Board.BoardDisplay(board);
            Console.WriteLine(" ");
            



            Console.Read();
            
        }
    }
}
