using System;
using System.Collections.Generic;

namespace Tik_Tak_Toe
{
    public static class Logic
    {
        

        public static bool WinLogic(List<XO.Square> squares)
        {
            if(!xWinLogic(squares) || !oWinLogic(squares))
            {
                return false;
            }
            else {return true;}
        }

        public static bool xWinLogic(List<XO.Square> squares)
        {
            if(SquareToString(squares[0]) == "X" && SquareToString(squares[1]) == "X" && SquareToString(squares[2]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[3]) == "X" && SquareToString(squares[4]) == "X" && SquareToString(squares[5]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[6]) == "X" && SquareToString(squares[7]) == "X" && SquareToString(squares[8]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[0]) == "X" && SquareToString(squares[3]) == "X" && SquareToString(squares[6]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[1]) == "X" && SquareToString(squares[4]) == "X" && SquareToString(squares[5]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[2]) == "X" && SquareToString(squares[5]) == "X" && SquareToString(squares[8]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[0]) == "X" && SquareToString(squares[4]) == "X" && SquareToString(squares[8]) == "X")
            {
                return false;
            }

            if(SquareToString(squares[2]) == "X" && SquareToString(squares[4]) == "X" && SquareToString(squares[6]) == "X")
            {
                return false;
            }

            

            else
                return true;
        }

        public static bool oWinLogic(List<XO.Square> squares)
        {
            if(SquareToString(squares[0]) == "O" && SquareToString(squares[1]) == "O" && SquareToString(squares[2]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[3]) == "O" && SquareToString(squares[4]) == "O" && SquareToString(squares[5]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[6]) == "O" && SquareToString(squares[7]) == "O" && SquareToString(squares[8]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[0]) == "O" && SquareToString(squares[3]) == "O" && SquareToString(squares[6]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[1]) == "O" && SquareToString(squares[4]) == "O" && SquareToString(squares[5]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[2]) == "O" && SquareToString(squares[5]) == "O" && SquareToString(squares[8]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[0]) == "O" && SquareToString(squares[4]) == "O" && SquareToString(squares[8]) == "O")
            {
                return false;
            }

            if(SquareToString(squares[2]) == "O" && SquareToString(squares[4]) == "O" && SquareToString(squares[6]) == "O")
            {
                return false;
            }

            else {return true;}
        }

        public static string SquareToString(XO.Square square) 
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