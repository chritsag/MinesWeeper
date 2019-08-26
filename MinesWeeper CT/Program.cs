using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesWeeper_CT
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldNumberToBePrinted = 1;


            // Read User Input
            InputReader reader = new InputReader();
            var userInputFields = reader.ReadUserInput();


            foreach (string[,] input in userInputFields)
            {
                Console.WriteLine("Field #" + fieldNumberToBePrinted + ":");
                fieldNumberToBePrinted++;

                Console.WriteLine();

                TablePrinter tablesToPrint = new TablePrinter();    
                tablesToPrint.MethodPrintTable(input);
     
            }


        }
    }
}