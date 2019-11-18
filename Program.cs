﻿using System;
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
                if(input.ToLower() == "y")
                {
                    restartInput = true;
                }
                else{ restartInput = false; }
            }
            while(restartInput);
        }

        static void Play()
        {
            List<XO.Square> Squares = new List<XO.Square> 
            {XO.Square.X, XO.Square.Empty, XO.Square.Empty, XO.Square.Empty, XO.Square.O,
            XO.Square.Empty, XO.Square.Empty, XO.Square.Empty, XO.Square.Empty};
            
            int turn = 1;
            int input = 0;
            bool play = true;
            string player = string.Empty;

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

                turn = TurnCounter(turn);
                bool success = int.TryParse(Console.ReadLine(), out input);

                Squares[input - 1] = TurnLogic(input, Squares[input - 1], success, turn);

                if(turn % 2 == 0)
                {
                    player = SquareToString(XO.Square.X);
                }
                else 
                    {player = SquareToString(XO.Square.O);}

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

            Console.WriteLine($"Congratulations player {player} has won.");
        }

        static XO.Square TurnLogic(int input,XO.Square square, bool success,int turn)
        {            
            if(success && input > 0 && input < 9 && square == XO.Square.Empty)
            {
                if(turn % 2 == 0)
                {
                    square = XO.Square.X;
                    return square;
                }
                else
                {
                    square = XO.Square.O;
                    return square;
                }
            }
            else {return square;}
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

        static int TurnCounter(int turn)
        {
            if(turn % 2 == 0)
            {
                Console.WriteLine($"O's turn, where would you like to play?");
                turn++;
                return turn;
            }
            else
            {
                Console.WriteLine($"X's turn, where would you like to play?");
                turn++;
                return turn;
            }
        }

        public static bool Restart(string input)
        {
            if(input == "Y")
            {
                return true;
            }
            else return false;
        }
    }
}