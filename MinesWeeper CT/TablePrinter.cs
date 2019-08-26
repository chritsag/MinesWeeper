using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesWeeper_CT
{
    public class TablePrinter
    {



        public string[,] MethodPrintTable(string[,] input)
        {


            int rowLength = input.GetLength(0);
            int colLength = input.GetLength(1);

            object[,] mineCounterTable = new object[rowLength, colLength];

            

            for (int i = 0; i < rowLength; i++)
            {

                for (int j = 0; j < colLength; j++)
                {

                    if (input[i, j] == "*")
                    {
                        mineCounterTable[i, j] = "*";

                    }

                    else if (input[i, j] == ".")
                    {
                        mineCounterTable[i, j] = 0;

                    }

                }


            }

          
            IncrementWhenMine(mineCounterTable);



            return null;
        }






        object IncrementWhenMine(object[,] mineCounterTable)
        {
            int rowLength = mineCounterTable.GetLength(0);
            int colLength = mineCounterTable.GetLength(1);


            for (int i = 0; i < rowLength; i++)
            {

                for (int j = 0; j < colLength; j++)
                {

                    if (mineCounterTable[i,j] == "*")
                    {
                        for (int x = -1; x < 2; x++)
                        {
                            for (int y = -1; y < 2; y++)
                            {

                        
                        try
                        {
                            mineCounterTable[i + x, j + y] = Convert.ToInt32(mineCounterTable[i + x, j + y]) + 1;

                        }
                        catch (Exception)
                        {

                            continue;
                        }
                        

                            }
                        }
                    }

                }
            }

                for (int i = 0; i < rowLength; i++)
                {

                    for (int j = 0; j < colLength; j++)
                    {

                        Console.Write(string.Format("{0} ", mineCounterTable[i, j]));

                    }


                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
                Console.WriteLine();


            return null;
        }

        }
           
    }

