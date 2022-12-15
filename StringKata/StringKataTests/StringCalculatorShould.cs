using System;
using Xunit;
using StringKata.Classes;

namespace String_Calculator_Kata.Tests
{
    public class StringCalculatorShould
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorShould()
        {
            this._stringCalculator = new StringCalculator();
        }


        [Fact]
        public void ShouldThrowArgumentNullExceptionIfInputStringIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this._stringCalculator.Add(null));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("\n", 0)]
        public void ShouldReturnZeroIfInputStringIsEmptyOrWhiteSpace(string numbers, int expectedSum)
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
        public void ShouldReturnCorrectSumOfOneNumberIfInputStringContainsOneNumberOnly(string numbers, int expectedSum)
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
        [InlineData("1\n2,100\n105", 208)]
        [InlineData("7, 9 \n 1082,999", 2097)]
        [InlineData("0, 0\n0, 0 \n0", 0)]
        [InlineData("1000, 2000\n 3000\n 4000", 10000)]
        public void ShouldReturnCorrectSumOfAllNumbersIfStringContainsMoreThanOneNumberSeparatedByCommasOrNewLineCharacters(string numbers, int expectedSum)
        {
            //Act
            var actual = this._stringCalculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

    }
}