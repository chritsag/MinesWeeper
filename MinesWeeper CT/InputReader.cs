using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesWeeper_CT
{
    public class InputReader
    {
        //creates a list to save the tables
        public List<string[,]> ReadUserInput()
        {
            
            List<string[,]> inputFields = new List<string[,]>();
            int rowCounter = 0;
          

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (IsHeading(inputLine))
                {
                    
                    rowCounter = 0;
                    // takes the numbers the users added and removes the gap
                    var fieldDimensions = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    // creates a table, with these dimensions
                    var nValue = int.Parse(fieldDimensions[0]);
                    var mValue = int.Parse(fieldDimensions[1]);

                    inputFields.Add(new string[nValue, mValue]);
                }
                else if (IsFieldInput(inputLine))
                {
                    //takes the last row of the table
                    var lastCreatedField = inputFields.Last();

                    // Read squares
                    for (int columnIndex = 0; columnIndex < inputLine.Length; columnIndex++)
                    {
                        lastCreatedField[rowCounter, columnIndex] = inputLine[columnIndex].ToString();
                    }

                    rowCounter++;
                }
                else if (IsEndOfInput(inputLine))
                {
                
                    break;
                }
            }

            
            return inputFields;
        }

        /// <summary>
        /// Checks if the input line contains squares
        /// </summary>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        private bool IsFieldInput(string inputLine)
        {
         
            var inputLineWithoutSpaces = inputLine.Trim();
            if (inputLineWithoutSpaces.StartsWith(Constants.MineSquare) || inputLineWithoutSpaces.StartsWith(Constants.SafeSquare))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the input contains digits 0-9 is heading
        /// </summary>
        /// <param name="lineInput"></param>
        /// <returns></returns>
        private bool IsHeading(string lineInput)
        {
            foreach (var character in lineInput)
            {
                if (character >= '1' && character <= '9')
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if n = m = 0
        /// </summary>
        /// <param name="lineInput"></param>
        /// <returns></returns>
        private bool IsEndOfInput(string lineInput)
        {
            if (lineInput.Trim().StartsWith("0"))
            {
                var inputArray = lineInput.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (inputArray.Length >= 2)
                {
                    // n = m = 0
                    if (inputArray[0] == "0" && inputArray[1] == "0")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
