using System;

namespace StringKata.Classes
{
    /*
    This class represents a String Calculator, which calculates the sum of the numbers, if any, inside a given String instance
    using its Add(string) method.
    */
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        /*
          Takes a String instance as input. Calculates and returns the sum of the numbers, if any, inside the given String instance.

          If the given String instance is Null, throws an ArgumentNullException. If not, makes a call to the helper method, 
          AddStringContents(), passing in the provided String instance and the delimiter(s) seperating the numbers inside 
          the provided String from one another. Default delimietrs are: "," and "\n" but the user can choose their own delimiters. 
        */
        public int Add(string numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Invalid input! Please make sure that the String you are providing is Not null.");
            }

            //Checks if the user chose to override the default delimiters. If so, extracts the new delimiter from the provided String. 
            if (numbers.HasACustomDelimiter())
            {
                return AddStringContents(numbers, numbers.ExtractDelimiter());
            }

            else
            {
                return AddStringContents(numbers, ",", "\n");
            }
        }

        /*
         Helper method takes in a String instance (the String the user passes to the Add() method) and a String array containing
         all the different delimiters to be used to separate the numbers from one another.

         Calculates and returns the sum of all the numbers inside the provided String instance after separating them according to the
         provided list of delimiters.
        */
        private int AddStringContents(string numbers, params string[] delimiters)
        {
            var sum = 0;
            foreach (var number in numbers.Split(delimiters, StringSplitOptions.None))
            {
                if (int.TryParse(number, out int value))
                {
                    sum += value;
                }
            }
            return sum;
        }
    }
}