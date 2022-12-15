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
        public void ShouldThrowArgumentNullExceptionIfTheInputStringIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this._stringCalculator.Add(null));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("\n", 0)]
        //Checks that the Add() method returns zero if the provided String instance is empty, whitespace, or empty lines.
        public void ShouldReturnZeroIfTheInputStringIsEmptyOrWhiteSpace(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }



        [Theory]
        [InlineData("0", 0)]
        [InlineData("7", 7)]
        [InlineData("13 ", 13)]
        [InlineData(" 173", 173)]
        [InlineData(" 1072183 ", 1072183)]
        //Checks that the Add() method returns the correct sum if the input String contains one number only (could have spaces around it).
        public void ShouldReturnCorrectSumOfOneNumber(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }


        [Theory]
        [InlineData("1,2,100,105", 208)]
        [InlineData("7, 9 , 1082,999", 2097)]
        [InlineData("0, 0,0, 0 ,0", 0)]
        [InlineData("1000, 2000, 3000, 4000", 10000)]
        public void ShouldReturnCorrectSumOfAllNumbersIfStringContainsMoreThanOneNumberSeparatedByCommas(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }
        [Theory]
        [InlineData("1,105", 106)]
        [InlineData("7, 9", 16)]
        [InlineData("0, 0", 0)]
        [InlineData("1000, 2000", 3000)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a comma.
        public void ShouldReturnCorrectSumOfTwoNumbersSeperatedByAComma(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("1,2,100,105", 208)]
        [InlineData("7, 9 , 1082,999", 2097)]
        [InlineData("0, 0,0, 0 ,0", 0)]
        [InlineData("1000, 2000, 3000, 4000", 10000)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a comma.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByAComma(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("1\n105", 106)]
        [InlineData("7\n 9", 16)]
        [InlineData("0\n 0", 0)]
        [InlineData("1000 \n 2000", 3000)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a new line.
        public void ShouldReturnCorrectSumOfTwoNumbersSeperatedByANewLine(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("1\n2\n100\n105", 208)]
        [InlineData("7\n 9 \n 1082\n999", 2097)]
        [InlineData("0\n 0\n0\n 0 \n0", 0)]
        [InlineData("1000\n 2000\n 3000\n 4000", 10000)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a new line.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByNewLines(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("1\n2,100\n105", 208)]
        [InlineData("7, 9 \n 1082,999", 2097)]
        [InlineData("0, 0\n0, 0 \n0", 0)]
        [InlineData("1000, 2000\n 3000\n 4000", 10000)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by commas or new lines.
        public void ShouldReturnCorrectSumOfAnUnknownAmountOfNumbersSeperatedByCommasAndNewLines(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("//;\n2;105", 107)]
        [InlineData("// \n7  999", 1006)]
        [InlineData("//n\n0n  0 ", 0)]
        [InlineData("//_\n1000_  4000", 5000)]
        //Checks that the Add() method returns the correct sum of two numbers separated by a custom delimiter.
        public void ShouldReturnCorrectSumOfTwoNumbersSeparatedByACustomDelimiter(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("//;\n1;2;100;105", 208)]
        [InlineData("// \n7  9   1082 999", 2097)]
        [InlineData("//n\n0n 0n0n 0 n0", 0)]
        [InlineData("//_\n1000_ 2000_ 3000_ 4000", 10000)]
        //Checks that the Add() method returns the correct sum of an unknown amount of numbers separated by a custom delimiter.
        public void ShouldReturnCorrectSumOfAllNumbersIfStringContainsMoreThanOneNumberSeparatedByCustomDelimiter(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);
            //Assert
            Assert.Equal(expectedSum, actual);
        }


    }
}