using StringKata.Classes;
using System;
using Xunit;

namespace StringKata.Tests
{
    /*
        This class contains a number of Test methods to test the functionality and the behavior of the StringExtension class.
    */
    public class StringExtensionsShould
    {
        [Theory]
        [MemberData(nameof(CustomDelimiterData.HasNoDelimiter), MemberType = typeof(CustomDelimiterData))]
        //Checks that the HasACustomDelimiter() method returns false if the calling String does not match the pattern of a String with a Delimiter.
        public void ShouldReturnFalseIfInputStringHasNoDelimiter(string numbers)
        {
            //Assert
            Assert.False(numbers.HasACustomDelimiter());
        }

        [Theory]
        [MemberData(nameof(CustomDelimiterData.HasADelimiter), MemberType = typeof(CustomDelimiterData))]
        //Checks that the HasACustomDelimiter() method returns true if the calling String matches the pattern of a String with a Delimiter.
        public void ShouldReturnTrueIfInputStringHasADelimiter(string numbers)
        {
            //Assert
            Assert.True(numbers.HasACustomDelimiter());
        }

        [Theory]
        [MemberData(nameof(CustomDelimiterData.HasNoDelimiter), MemberType = typeof(CustomDelimiterData))]
        //Checks that the ExtractDelimiter() method throws an ArgumentException with the correct error message if the calling String has no delimiter to be extracted.
        public void ShouldThrowArgumentExceptionWithCorrectErrorMessageIfInputStringHasNoDelimiterToBeExtracted(string numbers)
        {
            //Assert
            var actual = Assert.Throws<ArgumentException>(() => numbers.ExtractDelimiter());
            Assert.Equal("Invalid input! The input string you provided has no delimiters to be extracted.", actual.Message);
        }

        [Fact]
        //Checks that the ExtractDelimiter() method throws a NotSupportedException with the correct error message if the calling String has a delimiter the same as the minus operator "-".
        public void ShouldThrowANotSupportedExceptionWithCorrectErrorMessageIfDelimiterIsEqualToTheMinusOperator()
        {
            //Arrange
            var numbers = "//-\n1-2-3-4-5-1094";

            //Assert
            var actual = Assert.Throws<NotSupportedException>(() => numbers.ExtractDelimiter());
            Assert.Equal("The string: '-' is not a supported delimiter!", actual.Message);
        }

        [Theory]
        [InlineData("//;\n", ";")]
        [InlineData("//;\n1;2;2;3", ";")]
        [InlineData("// \n1 2 2 3", " ")]
        [InlineData("//plus\n1 plus 2 plus 2 plus 3", "plus")]
        //Checks that the ExtractDelimiter() method returns the correct delimiter if the calling String has a delimiter to be extracted.
        public void ShouldReturnCorrectDelimiterIfInputStringHasADelimiter(string numbers, string delimiter)
        {
            //Assert
            Assert.Equal(delimiter, numbers.ExtractDelimiter());
        }
    }
}