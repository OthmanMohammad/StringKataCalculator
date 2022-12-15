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
        //Checks that the ExtractDelimiter() method throws an ArgumentException if the calling String has no delimiter to be extracted.
        public void ShouldThrowArgumentExceptionIfInputStringHasNoDelimiterToBeExtracted(string numbers)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => numbers.ExtractDelimiter());
        }

        [Theory]
        [InlineData("//;\n", ";")]
        [InlineData("//;\n1;2;2;3", ";")]
        [InlineData("// \n1 2 2 3", " ")]
        [InlineData("//plus\n1 plus 2 plus 2 plus 3", "plus")]
        //Checks that the ExtractDelimiter() method should return the correct delimiter if the calling String has a delimiter to be extracted.
        public void ShouldReturnCorrectDelimiterIfInputStringHasADelimiter(string numbers, string delimiter)
        {
            //Assert
            Assert.Equal(delimiter, numbers.ExtractDelimiter());
        }
    }
}