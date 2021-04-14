using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    //displays the board
    public class Player
    {

        public string Name { get; set; }
        public string Piece { get; set; }
        public Player(string name, string piece)
        {
            Name = name;
            Piece = piece;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("Hello {0}", Name);
        }

    }

    class Player1 : Player
    {
        //will inherit from player
        public Player1(string name, string piece) : base(name, piece)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Hello {0}, you'll be 'X'", Name);
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
            Console.WriteLine("Hello {0}, you'll be 'O'", Name);
        }
    }

    class Computer : Player
    {
        public Computer(string name, string piece) : base(name, piece)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("You'll be playing against a Computer! 'O'");
        }

    }



    public class Board // Updated Lyndon
    {

        //add method to display and update board
        //check winning combination
        // restart game

        public Board()
        {

        }

        public static void BoardDisplay(string[,] board)  // method displaying the board
        {
            
            Console.WriteLine();
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
            Console.Write(" " + " 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 ");
            Console.WriteLine(" ");
        }



        public static bool RestartBoard(string[,] board) // method restarting the board
        {

            Console.WriteLine("Restart? Yes(1) No(0):");
            string num = Console.ReadLine();
            if (num == "1")
            {
                Console.Clear();
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
            //Doctor Krypto. (2020). C# Connect4 Console Game 4 Check for the Win [Video]. Youtube. https://www.youtube.com/watch?v=A-fl-Ui_8Wo&t=344s&ab_channel=DoctorKrypto
        }



        public static void WinnerPlayer(Player activePlayer) // display who is the winner
        {
            Console.WriteLine("");
            Console.WriteLine("The winner is {0}!({1})", activePlayer.Name, activePlayer.Piece);
        }
        
    }
    public class Controller // Updated By Andrie
    {
        //add method for the numbers(pick)
        //public void PlayerTurn()
        public static string _piece { get; set; } = "a";
        public static int _position { get; set; } = 0;

        public static void PlayerTurn(Player activePlayer)//displays whose turn it is
        {
            Console.WriteLine("Its {0}'s turn({1})", activePlayer.Name, activePlayer.Piece);
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


        public static string[,] CheckBottom(string[,] board) // checks the 'bottom' of the board
        {

            int i = 6;
            while (i >= 1)
            {
                if (board[i, _position] != " X " && board[i, _position] != " O ")
                {
                    board[i, _position] = _piece;
                    break;
                }
                else if (board[i, _position] == " X " || board[i, _position] == " O ")
                {
                    i--;

                }
            }


            return board;
        }
        
        public static string[,] DropPiece(string[,] board, string piece, int mode) //determines the placement of the piece
        {
            int pos;
            Random rnd = new Random();

            if(mode == 1 && piece == " O ")//computer selects a random number between 1 to 7
            {
                pos = rnd.Next(1, 8);
            }
            else
            {
                do
                {
                    Console.WriteLine("Select a location to place a piece: ");
                    pos = Convert.ToInt32(Console.ReadLine());
                    if (pos > 7 || pos < 1)
                    {
                        Console.WriteLine("Select 1 to 7 only.");
                    }

                } while (pos < 1 || pos > 7);

            }     

            if (board[1, pos] == " O " || board[1, pos] == " X ")
            {
                Console.WriteLine("Column is Full! Select a new one.");
                DropPiece(board, piece, mode);
            }

            _piece = piece;
            _position = pos;

  
            
            CheckBottom(board);

            return board;
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            //initiating board
            string[,] board = new string[8, 9];
            //initiating players
            string p1, p2;
            bool reset = true;
            bool fullBoard;

            //selecting between 1 player or 2 player game
            int mode;
            do
            {
                Console.Clear();
                Console.WriteLine("Select a game mode: \n1: Against Computer \n2: Against another Player");
                mode = Convert.ToInt32(Console.ReadLine());
            } while (mode > 2 || mode < 1);

            //takes in player information

            Console.WriteLine("Enter player information: ");
            Console.Write("Player 1: ");
            p1 = Console.ReadLine();
            Player player1 = new Player1(p1, " X ");
            Player player2;
            //initializes computer depending on the chosen mode

            if (mode == 1)
            {
                p2 = "Computer";
                player2 = new Computer(p2, " O ");
            }
            else
            {
                Console.Write("Player 2: ");
                p2 = Console.ReadLine();
                player2 = new Player2(p2, " O ");
            }         

            // displays player information

            player1.DisplayInfo();
            player2.DisplayInfo();

            Player active = player1;

            //start of the gameplay loop, first it shows the board

            Board.BoardDisplay(board);

            //signals the start of the game

            Console.WriteLine("\nGame Start");

            do
            {
                fullBoard = Board.FullBoard(board);//checks if the board is full
                if (fullBoard == true)
                {
                    Console.WriteLine("Game is a tie!");
                    reset = Board.RestartBoard(board);
                    if (reset == false)
                    {
                        break;
                    }
                }
                Controller.PreviousMove();
                Controller.PlayerTurn(active);
                Controller.DropPiece(board, active.Piece, mode);
                Console.Clear();
                Board.BoardDisplay(board);  //display board
                bool winner = Board.WinnerBoard(board, active);
                if (winner == true) //if condition to display when a player wins
                {
                    Board.WinnerPlayer(active); //display winner and ask user if they want to play again.
                    reset = Board.RestartBoard(board);
                    if (reset == false)
                    {
                        break;
                    }
                }

                if(active.Name == player1.Name)
                {
                    active = player2;
                }
                else if(active.Name == player2.Name)
                {
                    active = player1;
                }


            } while (reset == true);

            Console.Read();
            
        }
    }
    //Adapted from Github Gist Example
    //Title: Connect 4 Command Line C#
    //Author: Michael Estes
    //Date:2013
    //Code version: N/A
    //Availablity: https://gist.github.com/MichaelEstes/7953391
}
