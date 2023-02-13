using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata.Classes
{
    /*
        This static class represents a library of a number of frequently used extension methods. These extension methods are
        required to manipulate the String instance a user provides in order to check for and extract delimiters should any exist.
        Due to the complexity of these operations (checking for delimietrs and extracting them), it made sense to create an extension
        class with these operations encapsulated inside extension methods that can be easily invoked from any string instance.
    */
    public static class StringExtensions
    {
        /*
            Extension method checks whether or not the calling String instance contains a custom delimiter. 
        
            Does so by defining a regular expression for a String with a custom delimiter (using the Regex class)
            and checking for a match between the calling String isntance and the defined regular expression. If a match is found, 
            returns true, otherwise false is returned.
        */
        public static bool HasACustomDelimiter(this string numbers)
        {
            //Defines what a String with a custom delimiter expression should look like.
            var delimiterExpression = new Regex(@"^//[^.{1,}]+\n");

            if (delimiterExpression.IsMatch(numbers))
            {
                return true;
            }

            return false;
        }

        /*
            Extension method extracts the delimiter, if any, from the calling String instance.
        
            Does so by checking if the calling String instance has a delimiter. If it does, extracts and returns the delimiter, if supported,
            as a String using LINQ extensions. Otherwise, throws an ArgumentException.
        */
        public static string ExtractDelimiter(this string numbers)
        {
            if (!numbers.HasACustomDelimiter())
            {
                throw new ArgumentException("Invalid input! The input string you provided has no delimiters to be extracted.");
            }

            //Skips the first two characters then keeps adding characters to the delimiter string until it reaches the new line character.
            var delimiter = string.Concat(numbers.Skip(2).TakeWhile(x => !x.Equals('\n')));

            //If the delimiter is "-" throws a NotSupportedException as the minus operator is not a supported delimiter. Otherwise returns the extracted delimiter.
            return delimiter == "-" ? throw new NotSupportedException($"The string: '{delimiter}' is not a supported delimiter!") : delimiter;
        }
    }
}