using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    //skeleton code at its current state
    
    public class Player
    {

        public string Name { get; set; }
        public char Piece { get; set; }
        public Player (string name, string piece)
        {
            Name = name;
            Piece = piece;
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
        public Player1(string name, string piece) : base(name, piece)
        {

        }

        public override void testInfo()
        {
            Console.WriteLine("Hello {0}, you'll be '{1}'", Name, Piece);
        }


    }

    class Player2 : Player
    {
        //will inherit from player
        public Player2(string name, string piece) : base(name, piece)
        {

        }

        public override void testInfo()
        {
            Console.WriteLine("Hello {0}, you'll be '{1}'", Name, Piece);
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
                   
                    if (board[i, x] == " X " || board[i, x] == " O ")
                    {
                        Console.Write(board[i, x]);
                    }
                    else
                    {
                        board[i, x] = " # ";
                        Console.Write(board[i, x]);
                    }
                             
                    x++;
                }
                i++;
                Console.Write("| \n");
            }
            Console.Write(" "+" 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 ");
        }


        
        public static bool RestartBoard(string[,] board) // method restarting the board
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
                        board[i, x] = " # ";
                        Console.Write(board[i, x]);
                        x++;
                    }
                    i++;
                    Console.Write("| \n");
                }
                Console.WriteLine(" " + " 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 ");
                Console.WriteLine(" ");
                return true;
            }
            else
            {
                Console.WriteLine("Thank you for playing!");
                return false;
            }

        }

                public static bool WinnerBoard(string[,] board, Player activePlayer) // method checking winning combinations
        {
            bool winner = false;


            for (int i = 1; i <= 6; i++) // diagonal(up)
            {

                for (int x = 7; x >= 1; x--)
                {

                    if (board[i, x] == activePlayer.Piece && // check conditions if area is populated by the piece
                        board[i + 1, x - 1] == activePlayer.Piece &&
                        board[i + 2, x - 2] == activePlayer.Piece &&
                        board[i + 3, x - 3] == activePlayer.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 6; i++) // diagonal(down)
            {

                for (int x = 1; x <= 6; x++)
                {

                    if (board[i, x] == activePlayer.Piece && // check conditions if area is populated by the piece
                        board[i + 1, x + 1] == activePlayer.Piece &&
                        board[i + 2, x + 2] == activePlayer.Piece &&
                        board[i + 3, x + 3] == activePlayer.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 7; i++) // horizontal
            {

                for (int x = 1; x <= 6; x++)
                {

                    if (board[i, x] == activePlayer.Piece && // check conditions if area is populated by the piece
                        board[i, x + 1] == activePlayer.Piece &&
                        board[i, x + 2] == activePlayer.Piece &&
                        board[i, x + 3] == activePlayer.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 6; i++) // vertical
            {

                for (int x = 1; x <= 7; x++)
                {

                    if (board[i, x] == activePlayer.Piece && // check conditions if area is populated by the piece
                        board[i + 1, x] == activePlayer.Piece &&
                        board[i + 2, x] == activePlayer.Piece &&
                        board[i + 3, x] == activePlayer.Piece)
                    {
                        winner = true;
                    }

                }
            }



            return winner; // if player wins retrun true
        }

        public static void WinnerPlayer(Player activePlayer) // display who is the winner
        {
            Console.WriteLine("Winner is " + activePlayer.Name);
        }
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
        public static string[,] DropPiece(string[,] board, string piece)
        {
            int pos;
            do
            {
                Console.WriteLine("Select a location to place a piece: ");
                pos = Convert.ToInt32(Console.ReadLine());

            } while (pos < 1 || pos > 7);

            Console.WriteLine("'{0}' placed at column {1}", piece, pos);

            int i = 6;
            while (i >= 1)
            {
                if (board[i, pos] != " X " && board[i, pos] != " O ")
                {
                    board[i, pos] = piece;
                    break;
                }
                else if (board[i, pos] == " X " || board[i, pos] == " O ")
                {
                    i--;
                }
                else
                {
                    i--;

                }
            }
            //board[5, pos] = piece;
            return board;
        }


    }
    
   class Program
    {
        static void Main(string[] args)
        {

            // the main

            ////initiating players
            string[,] board = new string[8, 9];

            string p1, p2;
            bool reset = true;
            bool winner = false;
            Console.WriteLine("Enter player information: ");
            Console.Write("Player 1: ");
            p1 = Console.ReadLine();
            Console.Write("Player 2: ");
            p2 = Console.ReadLine();

            Player player1 = new Player1(p1, " X ");
            Player player2 = new Player2(p2, " O ");

            player1.testInfo();
            player2.testInfo();

            Player obj = player1;
            Player obj2 = player2;

            //gameplay loop
            Board.BoardDisplay(board);
            //display board
            Console.WriteLine("\nGame Start");
            do
            {
                Controller.PlayerTurn(obj);
                Controller.DropPiece(board, obj.Piece);
                Board.BoardDisplay(board);  //display board
                winner = Board.WinnerBoard(board, obj); //method to check /win
                if (winner == true) //if condition to display when player 1 wins 
                {
                    Board.WinnerPlayer(obj); //display winner and ask user if they want to play again.
                    reset = Board.RestartBoard(board);
                    if (reset == false)
                    {
                        break;
                    }
                } 
          
                Controller.PlayerTurn(obj2);
                Controller.DropPiece(board, obj2.Piece);
                Board.BoardDisplay(board);   //display board
                winner = Board.WinnerBoard(board, obj2);    //method to check win
                if (winner == true) //if condition to display when player 1 wins 
                {
                    Board.WinnerPlayer(obj2);  //display winner and ask user if they want to play again.
                    reset = Board.RestartBoard(board);
                    if (reset == false)
                    {
                        break;
                    }
                }


            } while (reset == true);

            Console.Read();
            
        }
    }
}
