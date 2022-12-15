using System;
using System.Linq;

namespace StringKata.Classes
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Invalid input! Please make sure that the input you are providing is not null.");
            }

            if (String.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            else
            {
                var sum = 0;
                var numbersArray = numbers.Split(',');
                foreach (var number in numbersArray)
                {
                    sum += int.Parse(number.Trim());
                }
                return sum;
            }
        }
    }
}