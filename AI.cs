using System;
using System.Collections.Generic;
using System.Linq;

namespace Tik_Tak_Toe
{
    public static class AI
    {

        //  Input Index:      Index:
        //   1 | 2 | 3     //   0 | 1 | 2 
        //  ----------     //  ----------
        //   4 | 5 | 6     //   3 | 4 | 5
        //  ----------     //  ----------
        //   7 | 8 | 9     //   6 | 7 | 8

        static Random rand = new Random();
        static List<XO.Square> Squares = new List<XO.Square>();
        static int TURN = 1;

        private static int TurnPlus(int turn)
        {
            return turn++;
        }

        public static void AiTurn(List<XO.Square> squareList)
        {
            switch (TURN)
            {
                case 1:
                    AiTurnOne(squareList);
                    TurnPlus(TURN);
                    break;
                case 2:
                    AiTurnTwo(squareList);
                    TurnPlus(TURN);
                    break;
                default:
                    break;
            }
        }


        public static void AiTurnOne(List<XO.Square> squareList)
        {
            Squares = squareList; //Bring the current Square list into class.

            if(Squares[4] == XO.Square.O)
                squareList[8] = XO.Square.X; //Place AI in a corner.                
            else
                squareList[4] = XO.Square.X;
        }

        private static void AiTurnTwo(List<XO.Square> squareList)
        {
            Squares = squareList;

            //Player took center.
            if(Squares[4] == XO.Square.O)
            {
                if (Squares[0] == XO.Square.O)
                {
                    squareList[6] = XO.Square.X;
                    goto FinishTurn;
                }

                if (Squares[1] == XO.Square.O || Squares[2] == XO.Square.O)
                {
                    squareList[7] = XO.Square.X;
                    goto FinishTurn;
                }

                if (Squares[3] == XO.Square.O)
                {
                    squareList[5] = XO.Square.X;
                    goto FinishTurn;
                }

                if (Squares[5] == XO.Square.O)
                {
                    squareList[3] = XO.Square.X;
                    goto FinishTurn;
                }

                if (Squares[6] == XO.Square.O)
                {
                    squareList[2] = XO.Square.X;
                    goto FinishTurn;
                }

                if (Squares[7] == XO.Square.O)
                {
                    squareList[1] = XO.Square.X;
                    goto FinishTurn;
                }
            }

            //Player took anywhere else.
            FinishTurn:
                return;
        }
    }

}