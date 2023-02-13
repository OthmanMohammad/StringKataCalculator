using System;
using Xunit;
using StringKata.Classes;

namespace String_Calculator_Kata.Tests
{
    /*
        This class contains a number of Test methods to test the functionality and the behavior of the StringCalculator class.
    */
    public class StringCalculatorShould
    {
        //Stores an instance of StringCalculator. Used throughout the test methods to reduce code repitition and duplication.
        private readonly StringCalculator _stringCalculator;

        /*
            Class constructor initializes a StringCalculatorShould instance by creating a StringCalculator isntance and storing
            it in the field above.
            Called before each test method to setup any required, repeated code or initilizations.
        */
        public StringCalculatorShould()
        {
            this._stringCalculator = new StringCalculator();
        }

        [Fact]
        //Checks that the Add() method throws an ArgumentException if the provided String isntance is null;
        public void ShouldThrowArgumentExceptionWithCorrectErrorMessageIfTheInputStringIsNull()
        {
            //Assert
            var actual = Assert.Throws<ArgumentException>(() => this._stringCalculator.Add(null));
            Assert.Equal("Invalid input! Please make sure that the string you are providing is NOT null.", actual.Message);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("\n", 0)]
        //Checks that the Add() method returns zero if the provided String instance is empty, whitespace, or empty lines.
        public void ShouldReturnZeroIfTheInputStringIsEmptyOrWhiteSpace(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("7", 7)]
        [InlineData("13 ", 13)]
        [InlineData(" 173", 173)]
        //Checks that the Add() method returns the correct sum if the input String contains one number only (could have spaces around it).
        public void ShouldReturnCorrectSumOfOneNumber(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("1,105", 106)]
        [InlineData("7, 9", 16)]
        [InlineData("0, 0", 0)]
        [InlineData("100, 200", 300)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a comma.
        public void ShouldReturnCorrectSumOfTwoNumbersSeperatedByAComma(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("1,2,100,105", 208)]
        [InlineData("7, 9 , 108,999", 1123)]
        [InlineData("0, 0,0, 0 ,0", 0)]
        [InlineData("100, 200, 300, 400", 1000)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a comma.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByAComma(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("1\n105", 106)]
        [InlineData("7\n 9", 16)]
        [InlineData("0\n 0", 0)]
        [InlineData("1000 \n 200", 1200)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a new line.
        public void ShouldReturnCorrectSumOfTwoNumbersSeperatedByANewLine(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("1\n2\n100\n105", 208)]
        [InlineData("7\n 9 \n 108\n999", 1123)]
        [InlineData("0\n 0\n0\n 0 \n0", 0)]
        [InlineData("1000\n 200\n 300\n 400", 1900)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a new line.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByNewLines(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("1\n2,100\n105", 208)]
        [InlineData("7, 9 \n 108,999", 1123)]
        [InlineData("0, 0\n0, 0 \n0", 0)]
        [InlineData("1000, 200\n 300\n 400", 1900)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by commas or new lines.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByCommasOrNewLines(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("//;\n2;105", 107)]
        [InlineData("// \n7  999", 1006)]
        [InlineData("//n\n0n  0 ", 0)]
        [InlineData("//_\n1000_  400", 1400)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a custom delimiter.
        public void ShouldReturnCorrectSumOfTwoNumbersSeparatedByACustomDelimiter(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("//;\n1;2;100;105", 208)]
        [InlineData("// \n7  9   108 999", 1123)]
        [InlineData("//n\n0n 0n0n 0 n0", 0)]
        [InlineData("//_\n1000_ 200_ 300_ 400", 1900)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a custom delimiter.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeparatedByACustomDelimiter(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }

        [Fact]
        //Checks that a NotSupportedException is thrown if we try to pass a numbers String whose delimiter is "-" to the Add() method.
        public void ShouldThrowNotSupportedExceptionWithCorrectErrorMessageIfTheDelimiterIsTheMinusOperator()
        {
            //Arrange
            var numbers = "//-\n1000- 200- 300-400";

            //Assert
            var actual = Assert.Throws<NotSupportedException>(() => this._stringCalculator.Add(numbers));
            Assert.Equal("The string: '-' is not a supported delimiter!", actual.Message);
        }

        [Fact]
        //Checks that the Add() method throws a NotSupportedException and Prints the correct error message if the provided numbers String contains one or more negatives.
        public void ShouldThrowNotSupportedExceptionWithCorrectErrorMessageIfInputStringContainsOneOrMoreNegativeNumbers()
        {
            //Arrange
            var input1 = "1, 4, -1, 3";
            var input2 = "//plus\n1plus-5plus 3 plus4";
            var input3 = "-1, 7, -1000, -93, 10, -909, 1, 0";
            var input4 = "//foo\n-1foo-5foo 3 foo-4 foo -1000foo -918";

            //Assert
            var actual1 = Assert.Throws<NotSupportedException>(() => this._stringCalculator.Add(input1));
            var actual2 = Assert.Throws<NotSupportedException>(() => this._stringCalculator.Add(input2));
            var actual3 = Assert.Throws<NotSupportedException>(() => this._stringCalculator.Add(input3));
            var actual4 = Assert.Throws<NotSupportedException>(() => this._stringCalculator.Add(input4));
            Assert.Equal("negatives not allowed: -1", actual1.Message);
            Assert.Equal("negatives not allowed: -5", actual2.Message);
            Assert.Equal("negatives not allowed: -1, -1000, -93, -909", actual3.Message);
            Assert.Equal("negatives not allowed: -1, -5, -4, -1000, -918", actual4.Message);
        }

        [Theory]
        [InlineData("1005", 0)]
        [InlineData("1004, 4084, 19984, 9183742", 0)]
        [InlineData("7000, 5 \n9999\n4, 98739\n 1", 10)]
        [InlineData("//_\n1050_ 2000_30000_ 400000", 0)]
        [InlineData("//'\n1000'20000' 30090'400 '5'100000 ' 10", 1415)]
        //Checks that the Add() method ignores numbers larger than 1000 when calculating the sum.
        public void ShouldIgnoreNumbersGreaterThanOneThousand(string numbers, int expectedSum)
        {
            //Assert
            Assert.Equal(expectedSum, this._stringCalculator.Add(numbers));
        }
    }

}