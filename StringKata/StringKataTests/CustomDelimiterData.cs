using System.Collections.Generic;

namespace StringKata.Tests
{
    /*
        This class defines two MemeberData properties; one with Strings that have a valid delimiter and the other
        with Strings that don't have a valid delimiter. 
        These properties are used in the StringExtensionsShould class to reduce code repitition and clean up the design.
    */
    public class CustomDelimiterData
    {
        public static IEnumerable<object[]> HasADelimiter
        {
            get
            {
                yield return new object[] { "//;\n" };
                yield return new object[] { "//;\n1;2;2;3" };
                yield return new object[] { "// \n1 2 2 3" };
                yield return new object[] { "//plus\n1 plus 2 plus 2 plus 3" };
            }
        }

        public static IEnumerable<object[]> HasNoDelimiter
        {
            get
            {
                yield return new object[] { "" };
                yield return new object[] { "//\n1 2 2 3" };
                yield return new object[] { "1,2,2,3" };
            }
        }
    }
}