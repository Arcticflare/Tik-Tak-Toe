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
        static XO.Square X = XO.Square.X;
        static XO.Square O = XO.Square.O;
        static XO.Square Empty = XO.Square.Empty;

        public static void AiTurn(List<XO.Square> squareList,int turn)
        {
            Squares = squareList;
            bool CENTER = false;
            if (Squares[4] == O)
            {
                CENTER = true;
            }

            switch (turn)
            {
                case 2:
                    AiTurnOne(squareList, CENTER);
                    turn++;
                    break;
                case 4:
                    AiTurnTwo(squareList, CENTER);
                    turn++;
                    break;
                case 6:
                    AiTurnThree(squareList, CENTER);
                    turn++;
                    break;
                case 8:
                    AiTurnFour(squareList, CENTER);
                    turn++;
                    break;
                case 10:
                    AiTurnFive(squareList, CENTER);
                    turn++;
                    break;
                default:
                    break;
            }
        }


        public static void AiTurnOne(List<XO.Square> squareList, bool center)
        {
            if(Squares[4] == O)
                squareList[8] = X; //Place AI in a corner.                
            else
                squareList[4] = X; // Place AI in center.
        }

        private static void AiTurnTwo(List<XO.Square> squareList, bool center)
        {
            
            //Player took center.
            if(center)
            {
                if (Squares[0] == O)
                {
                    squareList[6] = X;
                    goto FinishTurn;
                }

                if (Squares[1] == O )
                {
                    squareList[7] = X;
                    goto FinishTurn;
                }

                if (Squares[2] == O)
                {
                    squareList[6] = X;
                    goto FinishTurn;
                }

                if (Squares[3] == O)
                {
                    squareList[5] = X;
                    goto FinishTurn;
                }

                if (Squares[5] == O)
                {
                    squareList[3] = X;
                    goto FinishTurn;
                }

                if (Squares[6] == O)
                {
                    squareList[2] = X;
                    goto FinishTurn;
                }

                if (Squares[7] == O)
                {
                    squareList[1] = X;
                    goto FinishTurn;
                }

                if(squareList[8] == O)
                {
                    squareList[2] = X;
                    goto FinishTurn;
                }
            }

            //Player took anywhere else.
            if(!center)
            {
                int indexNo = 0;
                int index = AITurnLogic(squareList, indexNo);   
                switch (index)
                {
                    case 1:
                        Squares[2] = X;
                        break;
                    case 2:
                        Squares[1] = X;
                        break;
                    case 3:
                        Squares[0] = X;
                        break;
                    case 5:
                        Squares[1] = X;
                        break;
                    case 6:
                        Squares[0] = X;
                        break;
                    case 7:
                        Squares[8] = X;
                        break;
                    case 8:
                        Squares[7] = X;
                        break;
                    default:
                        break;
                }        
            }

            FinishTurn:
                return;
        }

        private static void AiTurnThree(List<XO.Square> squareList, bool center)
        {
            //Player has center.
            if(center)
            {
                if(Squares[5] == O)
                {
                    Squares[3] = X;
                    goto FinishTurn;
                }

                if (Squares[1] == O || Squares[3] == O)
                {
                    Squares[5] = X;
                    goto FinishTurn;
                }

                if (Squares[7] == O)
                {
                    Squares[2] = X;
                    goto FinishTurn;
                }

                FinishTurn:
                    return;
            }

            if(!center)
            {
                int indexNo = 1;
                int index = AITurnLogic(squareList, indexNo);

                switch (index)
                {
                    case 1:
                        if (Squares[3] == O || Squares[5] == O || Squares[7] == O || Squares[8] == O)
                        {
                            Squares[6] = X;
                        }
                        else
                        {
                            Squares[3] = X;
                        }
                        break;
                    case 2:
                        if (Squares[3] == O || Squares[5] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[7] = X;
                        }
                        else
                        {
                            Squares[3] = X;
                        }
                        break;
                    case 3:
                        if (Squares[2] == O || Squares[5] == O || Squares[7] == O || Squares[8] == O)
                        {
                            Squares[1] = X;
                        }
                        else
                        {
                            Squares[6] = X;
                        }
                        break;
                    case 4:
                        if (Squares[2] == O || Squares[3] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[7] = X;
                        }
                        else
                        {
                            Squares[6] = X;
                        }
                        break;
                    case 5:
                        if (Squares[1] == O || Squares[2] == O || Squares[7] == O || Squares[8] == O)
                        {
                            Squares[5] = X;
                        }
                        else
                        {
                            Squares[1] = X;
                        }
                        break;
                    case 6:
                        if (Squares[1] == O || Squares[2] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[5] = X;
                        }
                        else
                        {
                            Squares[2] = X;
                        }
                        break;
                    case 7:
                        if (Squares[2] == O || Squares[3] == O || Squares[5] == O || Squares[6] == O)
                        {
                            Squares[1] = X;
                        }
                        else
                        {
                            Squares[2] = X;
                        }
                        break;
                    case 8:
                        if (Squares[3] == O || Squares[5] == O || Squares[6] == O || Squares[7] == O)
                        {
                            Squares[8] = X;
                        }
                        else
                        {
                            Squares[5] = X;
                        }
                        break;
                    case 9:
                        if (Squares[2] == O || Squares[5] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[8] = X;
                        }
                        else
                        {
                            Squares[2] = X;
                        }
                        break;
                    case 10:
                        if (Squares[0] == O || Squares[3] == O || Squares[7] == O || Squares[8] == O)
                        {
                            Squares[6] = X;
                        }
                        else
                        {
                            Squares[9] = X;
                        }
                        break;
                    case 11:
                        if (Squares[0] == O || Squares[2] == O || Squares[7] == O || Squares[8] == O)
                        {
                            Squares[5] = X;
                        }
                        else
                        {
                            Squares[9] = X;
                        }
                        break;
                    case 12:
                        if (Squares[0] == O || Squares[2] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[5] = X;
                        }
                        else
                        {
                            Squares[2] = X;
                        }
                        break;
                    case 13:
                        if (Squares[1] == O || Squares[2] == O || Squares[6] == O || Squares[7] == O)
                        {
                            Squares[5] = X;
                        }
                        else
                        {
                            Squares[2] = X;
                        }
                        break;
                    case 14:
                        if (Squares[1] == O || Squares[5] == O || Squares[6] == O || Squares[7] == O)
                        {
                            Squares[8] = X;
                        }
                        else
                        {
                            Squares[5] = X;
                        }
                        break;
                    case 15:
                        if (Squares[1] == O || Squares[3] == O || Squares[6] == O || Squares[7] == O)
                        {
                            Squares[0] = X;
                        }
                        else
                        {
                            Squares[1] = X;
                        }
                        break;
                    case 16:
                        if (Squares[1] == O || Squares[3] == O || Squares[5] == O || Squares[7] == O)
                        {
                            Squares[8] = X;
                        }
                        else
                        {
                            Squares[7] = X;
                        }
                        break;
                    case 17:
                        if (Squares[0] == O || Squares[1] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[3] = X;
                        }
                        else
                        {
                            Squares[0] = X;
                        }
                        break;
                    case 18:
                        if (Squares[0] == O || Squares[1] == O || Squares[6] == O || Squares[7] == O)
                        {
                            Squares[3] = X;
                        }
                        else
                        {
                            Squares[1] = X;
                        }
                        break;
                    case 19:
                        if (Squares[0] == O || Squares[2] == O || Squares[6] == O || Squares[8] == O)
                        {
                            Squares[7] = X;
                        }
                        else
                        {
                            Squares[6] = X;
                        }
                        break;
                    case 20:
                        if (Squares[0] == O || Squares[1] == O || Squares[5] == O || Squares[8] == O)
                        {
                            Squares[2] = X;
                        }
                        else
                        {
                            Squares[0] = X;
                        }
                        break;
                    case 21:
                        if (Squares[0] == O || Squares[2] == O || Squares[5] == O || Squares[6] == O)
                        {
                            Squares[1] = X;
                        }
                        else
                        {
                            Squares[6] = X;
                        }
                        break;
                    case 22:
                        if (Squares[0] == O || Squares[2] == O || Squares[3] == O || Squares[8] == O)
                        {
                            Squares[1] = X;
                        }
                        else
                        {
                            Squares[0] = X;
                        }
                        break;
                    case 23:
                        if (Squares[1] == O || Squares[2] == O || Squares[3] == O || Squares[6] == O)
                        {
                            Squares[0] = X;
                        }
                        else
                        {
                            Squares[6] = X;
                        }
                        break;
                    case 24:
                        if (Squares[0] == O || Squares[1] == O || Squares[3] == O || Squares[7] == O)
                        {
                            Squares[6] = X;
                        }
                        else
                        {
                            Squares[7] = X;
                        }
                        break;
                    case 25:
                        if (Squares[1] == O || Squares[2] == O || Squares[3] == O || Squares[5] == O)
                        {
                            Squares[0] = X;
                        }
                        else
                        {
                            Squares[3] = X;
                        }
                        break;
                    case 26:
                        if (Squares[0] == O || Squares[2] == O || Squares[3] == O || Squares[5] == O)
                        {
                            Squares[1] = X;
                        }
                        else
                        {
                            Squares[3] = X;
                        }
                        break;
                    case 27:
                        if (Squares[0] == O || Squares[1] == O || Squares[3] == O || Squares[5] == O)
                        {
                            Squares[2] = X;
                        }
                        else
                        {
                            Squares[5] = X;
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        private static void AiTurnFour(List<XO.Square> squareList, bool center)
        {
            //Player has center.
            if(center)
            {
                if(Squares[1] == O)
                {
                    Squares[7] = X;
                    goto FinishTurn;
                }
                //This is wrong, fix it.
                if(Squares[6] == O)
                {
                    Squares[2] = X;
                    goto FinishTurn;
                }
                if (Squares[7] == O)
                {
                    Squares[1] = X;
                    goto FinishTurn;
                }
                FinishTurn:
                    return;
            }
        }

        private static void AiTurnFive(List<XO.Square> squareList, bool center)
        {
            //Draw game!
            for (int i = 0; i < squareList.Count; i++)
            {
                if (squareList[i] == Empty)
                {
                    squareList[i] = X;
                    Logic.Restart();
                }
            }
        }

        private static int AITurnLogic(List<XO.Square> squareList, int indexNo)
        {
            bool truth = false;
            int index = 1;

            //Iterate through all possible combinations where the player can go.
            for (int i = 0; i <= 8; i++)
            {
                while(index <= 8 && !truth)
                {
                    //when a combination has been found ex.. Played in square 1 & 2. set to true and save that index number.
                    if (squareList[index] == O && squareList[i] == O){ truth = true; }

                    //This number is set when true to index(players second turn square).
                    if (truth){ indexNo = index; }

                    index++;
                }
                index = i + 2;
            }
            return indexNo;
        }
    }

}