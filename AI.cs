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
                    break;
                case 10:
                    AiTurnFive(squareList, CENTER);
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

                if (Squares[1] == O || Squares[2] == O)
                {
                    squareList[7] = X;
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
            }

            //Player took anywhere else.
            if(!center)
            {
                int index = 0;
                AICombination(squareList, index);   
                switch (index)
                {
                    case 1:
                        Squares[2] = X;
                        break;
                    case 2:
                        Squares[1] = X;
                        break;
                    case 3:
                        Squares[6] = X;
                        break;
                    case 5:
                        Squares[1] = X;
                        break;
                    case 6:
                        Squares[3] = X;
                        break;
                    case 7:
                        Squares[3] = X;
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

                if (Squares[1] == O || Squares[3] == O || Squares[7] == O)
                {
                    //Computer win.
                    Squares[5] = X;
                    goto FinishTurn;
                }
            }

            if(!center)
            {
                //Computer wins.
                if(squareList[3] == O || squareList[5] == O || squareList[7] == O || squareList[8] == O)
                {
                    Squares[7] = X;
                    goto FinishTurn;
                }

                if(squareList[3] == O || squareList[5] == O || squareList[6] == O || squareList[8] == O)
                {
                    Squares[7] = X;
                    goto FinishTurn;
                }

                if(squareList[1] == O || squareList[5] == O || squareList[7] == O || squareList[8] == O)
                {
                    Squares[2] = X;
                    goto FinishTurn;
                }

                if(squareList[2] == O || squareList[3] == O || squareList[7] == O || squareList[8] == O)
                {
                    Squares[7] = X;
                    goto FinishTurn;
                }

                if(squareList[1] == O || squareList[2] == O || squareList[7] == O || squareList[8] == O)
                {
                    Squares[5] = X;
                    goto FinishTurn;
                }

                if(squareList[1] == O || squareList[2] == O || squareList[6] == O || squareList[8] == O)
                {
                    Squares[5] = X;
                    goto FinishTurn;
                }

                if(squareList[2] == O || squareList[3] == O || squareList[5] == O || squareList[6] == O)
                {
                    Squares[1] = X;
                    goto FinishTurn;
                }

                //Draws.
                if(squareList[3] == O || squareList[5] == O || squareList[6] == O || squareList[7] == O)
                {
                    Squares[8] = X;
                    goto FinishTurn;
                }

                if(squareList[1] == O || squareList[5] == O || squareList[7] == O || squareList[8] == O)
                {
                    Squares[2] = X;
                    goto FinishTurn;
                }
            }

            FinishTurn:
                return;
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
                if(Squares[6] == O)
                {
                    Squares[7] = X;
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

                    Console.WriteLine("Restart? Y/N");
                    string input = Console.ReadLine();
                    Logic.Restart(input);
                }
            }
        }

        public static int AICombination(List<XO.Square> squareList, int indexNo)
        {
            //Iterate through all possible combinations where the player can go.
            int index = 1;
            for (int i = 0; i < 9; i++)
            {
                bool truth = false;
                while(index < 9 && !truth)
                {
                    //when a combination has been found ex.. Played in square 1 & 2. set to true and save that index number.
                    if (squareList[index] == O && squareList[i] == O){ truth = true; }
                    //Console.WriteLine($" {i} - {index}  ----> {truth}");

                    //This number is set when true to index(players second turn square).
                    if (truth){ indexNo = index; }

                    index++;
                }
                index = i + 2;
            }
            Console.WriteLine(indexNo);
            return indexNo;
        }
    }

}