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

        public virtual void DisplayInfo()
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

        public override void DisplayInfo()
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

        public override void DisplayInfo()
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
        
        public static bool FullBoard(string[,] board) //checks if the top row is occupied
        {
            bool full = false;
            if(board[1, 1] != " # " &&
               board[1, 2] != " # " &&
               board[1, 3] != " # " &&
               board[1, 4] != " # " &&
               board[1, 5] != " # " &&
               board[1, 6] != " # " &&
               board[1, 7] != " # ")
            {
                full = true;
            }

            return full;
        }
        
        

         public static bool WinnerBoard(string[,] board, Player player) // method checking winning combinations
        {
            bool winner = false;


            for (int i = 1; i <= 6; i++) // diagonal(up)
            {

                for (int x = 7; x >= 1; x--)
                {
                    // check conditions if area is populated by the piece
                    if (board[i, x] == player.Piece &&  board[i + 1, x - 1] == player.Piece &&  board[i + 2, x - 2] == player.Piece && board[i + 3, x - 3] == player.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 6; i++) // diagonal(down)
            {

                for (int x = 1; x <= 6; x++)
                {
                    // check conditions if area is populated by the piece
                    if (board[i, x] == player.Piece && board[i + 1, x + 1] == player.Piece && board[i + 2, x + 2] == player.Piece && board[i + 3, x + 3] == player.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 7; i++) // horizontal
            {

                for (int x = 1; x <= 6; x++)
                {
                    // check conditions if area is populated by the piece
                    if (board[i, x] == player.Piece && board[i, x + 1] == player.Piece && board[i, x + 2] == player.Piece && board[i, x + 3] == player.Piece)
                    {
                        winner = true;
                    }

                }
            }

            for (int i = 1; i <= 6; i++) // vertical
            {

                for (int x = 1; x <= 7; x++)
                {
                    // check conditions if area is populated by the piece
                    if (board[i, x] == player.Piece && board[i + 1, x] == player.Piece && board[i + 2, x] == player.Piece && board[i + 3, x] == player.Piece)
                    {
                        winner = true;
                    }

                }
            }



            return winner; // if player wins retrun true
           //WinnerBoard adapted from
           //Doctor Krypto. (2020). C# Connect4 Console Game 4 Check for the Win [Video]. Youtube. https://www.youtube.com/watch?v=A-fl-Ui_8Wo&t=344s&ab_channel=DoctorKrypto
        }       

         public static void WinnerPlayer(Player player) // display who is the winner
        {
            Console.WriteLine("");
            Console.WriteLine("Winner is " + player.Name);
        }
    }
    
    
    public class Controller // Updated By Andrie
    {
        //add method for the numbers(pick)
        //add method to restart
        //public void PlayerTurn()
        
        public static string _piece { get; set; } = "a";
        public static int _position { get; set; } = 0;

         public static void PlayerTurn(Player player)
        {
            Console.WriteLine("Its {0}'s turn", player.Name);
        }
        
        public static void PreviousMove()
        {
            if (_piece == "a" && _position == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("'{0}' placed at column {1}", _piece, _position);
            }

        }

        
        public static string[,] DropPiece(string[,] board, string piece)
        {
            int pos;
            do
            {
                Console.WriteLine("Select a location to place a piece: ");
                pos = Convert.ToInt32(Console.ReadLine());

            } while (pos < 1 || pos > 7);

            _piece = piece;
            _position = pos;

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
            
            return board;
        }


    }
    
   class Program
    {
       
       
        public static void UserChoice(string [,] board, string p1, string p2, bool reset, bool winner, Player obj, Player obj2, bool fullBoard)
        {

            while (reset == true)
            {
                fullBoard = Board.FullBoard(board);//checks if the board is full
                if (fullBoard == true)
                {
                    Console.WriteLine("Game is a tie!");
                    break;
                }

                Controller.PreviousMove();
                Controller.PlayerTurn(obj);
                Controller.DropPiece(board, obj.Piece);
                Board.BoardDisplay(board);  //display board
                winner = Board.WinnerBoard(board, obj); //method to check /win
                if (winner == true) //if condition to display when player 1 wins 
                {
                    Board.WinnerPlayer(obj); //display winner and ask user if they want to play again.
                    break;
                }

                fullBoard = Board.FullBoard(board);//checks if the board is full
                if (fullBoard == true)
                {
                    Console.WriteLine("Game is a tie!");
                    break;
                }

                Controller.PreviousMove();
                Controller.PlayerTurn(obj2);
                Controller.DropPiece(board, obj2.Piece);
                Board.BoardDisplay(board);   //display board                
                winner = Board.WinnerBoard(board, obj2);    //method to check win
                if (winner == true) //if condition to display when player 1 wins 
                {
                    Board.WinnerPlayer(obj2);  //display winner and ask user if they want to play again.
                    break;
                }
            }
           
        }
       
        static void Main(string[] args)
        {

           
             string[,] board = new string[8, 9];

            string p1, p2;
            bool reset = true;
            bool winner = false;
            bool fullBoard = true;
            do
            {
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

                UserChoice(board, p1, p2, reset, winner, obj, obj2, fullBoard);

                reset = Board.RestartBoard(board); //after winner results ask user for a restart
                if (reset == false)
                {
                    break;
                }

            } while (reset == true);
            

            Console.Read();
            
            
            //Adapted from Github Gist Example
            //Title: Connect 4 Command Line C#
            //Author: Michael Estes
            //Date:2013
            //Code version: N/A
            //Availablity: https://gist.github.com/MichaelEstes/7953391
            
        }
    }
}
