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
                throw new ArgumentException("Invalid input! Please make sure that the string you are providing is NOT null.");
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
            all the different delimiters to be used to separate the numbers from one another as input.
            Calculates and returns the sum of all the numbers inside the provided String instance. To do so, this method:
                1. Converts the provided String instance into a List of int by making a call to the helper method, ExtractListOfNumbers()
                   and passing in the provided String instance and the String array containing the delimiters.
                2. Checks if the List of int contains any negative numbers by calling the helper method, HasNegativeNumbers() and passing
                   in the List of int. If it does, throws a NotSupportedException with a message containing all the negative numbers in the List.
                3. Calculates and returns the sum of the non-negative, less than 1001, numbers in the List.
        */
        private int AddStringContents(string numbers, params string[] delimiters)
        {
            var numbersList = ExtractListOfNumbers(numbers, delimiters);

            //Checks if the list contains any negative numbers, if so, throws a NotSupportedException.
            if (HasNegativeNumbers(numbersList))
            {
                throw new NotSupportedException("negatives not allowed: " + GetNegativeNumbers(numbersList));
            }

            return numbersList.Where(x => x <= 1000).Sum();
        }

        /*
            Helper method checks if a given IEnumerable<int> instance contains any negative numbers. Takes an IEnumerable<int> instance
            as input and uses LINQ extensions to check if it contains any negative numbers. Returns true if it does and false if otherwise.
        */
        private bool HasNegativeNumbers(IEnumerable<int> numbersList)
        {
            return numbersList.Any(x => x < 0);
        }

        /*
            Helper method returns a string containing all the negative numbers inside a given IEnumerable<int> isnatnce seperated by a comma.
            Takes an IEnumerable<int> isnatnce as input and uses the String class Join() method as well as LINQ extensions to create a String
            with all the negative numbers inside the provided IEnumerable<int> seperated by a comma. Returns the resulting String.
        */
        private string GetNegativeNumbers(IEnumerable<int> numbersList)
        {
            return String.Join(", ", numbersList.Where(x => x < 0).Select(x => x.ToString()));
        }

        /*
            Helper method extracts and returns the List of all the numbers, if any, from a given String instance provided the seperation delimiters.
            Does so by using the Split() method to split the String instance at each delimiter occurrence, then uses LINQ extensions to try and 
            Parse each resulting String into an int. Selects the Strings that can be Parsed to int and converts the resulting IEnumerable<int>
            to a List<int>. Returns the resulting List<int>.
        */
        private List<int> ExtractListOfNumbers(string numbers, params string[] delimiters)
        {
            return numbers.Split(delimiters, StringSplitOptions.None).Where(x => int.TryParse(x, out int value)).Select(int.Parse).ToList();
        }
    }
}