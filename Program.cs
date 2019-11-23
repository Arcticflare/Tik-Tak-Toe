using System;
using System.Collections.Generic;

namespace Tik_Tak_Toe
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool restartInput = false;
            do
            {
                Play();
                

                Console.WriteLine("Restart? Y/N");
                string input = Console.ReadLine();

                restartInput = Logic.Restart(input);
            }
            while(restartInput);
        }

        static void Play()
        {
            List<XO.Square> Squares = new List<XO.Square> 
            {XO.Square.O, XO.Square.O, XO.Square.Empty, XO.Square.Empty, XO.Square.X,
            XO.Square.Empty, XO.Square.Empty, XO.Square.Empty, XO.Square.Empty};
            
            int turn = 1;
            int input = 0;
            bool play = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Turn: {turn}.");
                Console.WriteLine("");
                Console.WriteLine($" {SquareToString(Squares[0])} | {SquareToString(Squares[1])} | {SquareToString(Squares[2])}");
                Console.WriteLine("------------");
                Console.WriteLine($" {SquareToString(Squares[3])} | {SquareToString(Squares[4])} | {SquareToString(Squares[5])}");
                Console.WriteLine("------------");
                Console.WriteLine($" {SquareToString(Squares[6])} | {SquareToString(Squares[7])} | {SquareToString(Squares[8])}");
                Console.WriteLine("");

                int index = 0;
                AI.AICombination(Squares, index);

                // Is it AI turn?
                if (turn % 2 == 0)
                {
                    Console.WriteLine("Computers turn.");
                    AI.AiTurn(Squares, turn);
                }
                else
                {
                    Console.WriteLine("It's your turn, where would you like to play?");
                    bool success = int.TryParse(Console.ReadLine(), out input);
                    Squares[input - 1] = TurnLogic(input, Squares[input - 1], success, turn, Squares);                    
                }

                turn++;

                if(!Logic.WinLogic(Squares))
                {
                    play = false;
                }                            
            }
            while(play);

            Console.WriteLine("");
            Console.WriteLine($"Turn: {turn}.");
            Console.WriteLine("");
            Console.WriteLine($" {SquareToString(Squares[0])} | {SquareToString(Squares[1])} | {SquareToString(Squares[2])}");
            Console.WriteLine("------------");
            Console.WriteLine($" {SquareToString(Squares[3])} | {SquareToString(Squares[4])} | {SquareToString(Squares[5])}");
            Console.WriteLine("------------");
            Console.WriteLine($" {SquareToString(Squares[6])} | {SquareToString(Squares[7])} | {SquareToString(Squares[8])}");
            Console.WriteLine("");
        }

        static XO.Square TurnLogic(int input,XO.Square square, bool success,int turn, List<XO.Square> Squares)
        {            
            if(success && input > 0 && input < 10 && square == XO.Square.Empty)
            {
                return square = XO.Square.O;
            }
            else {throw new System.ArgumentException("Invalid Index");}
        }
        
        static string SquareToString(XO.Square square) 
        {
            switch(square)
            {
                case XO.Square.X:
                    return "X";
                case XO.Square.O:
                    return "O";
                case XO.Square.Empty:
                    return " ";
                default:
                    throw new System.ArgumentException("Invalid Enum");
            }
        }
    }
}
