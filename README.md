# String Calculator Kata

This project implements the String Calculator Kata, a programming exercise to practice test-driven development (TDD) and software design principles.

## Overview

The String Calculator Kata involves building a calculator that can take a string of numbers separated by commas or new lines, and return their sum. The calculator should be able to handle an unknown amount of numbers, and it should also support custom delimiters specified at the beginning of the input string.

## Requirements

- The calculator should take a string of numbers as input, and return their sum.
- The input string can contain an unknown amount of numbers.
- The input string can use commas or new lines to separate numbers.
- The input string can have a custom delimiter specified at the beginning, in the form of `//[delimiter]\n`.
- The calculator should ignore numbers greater than 1000.
- The calculator should throw an exception if the input string contains negative numbers.

## Prerequisites

- Familiarity with C# programming language and .NET Core framework.
- Basic understanding of test-driven development (TDD) and software design principles.

## Libraries to Install

- xUnit.net: A free, open source, community-focused unit testing tool for the .NET Framework. To install, run the following command: `dotnet add package xunit`

## Project Structure

- `StringCalculator.cs`: A class that contains the logic for adding numbers in a string.
- `StringExtensions.cs`: An extension method that extracts a custom delimiter from a string.
- `CustomDelimiterData.cs`: A class that contains properties with test data for custom delimiter strings.
- `StringCalculatorShould.cs`: A class that contains unit tests for the `StringCalculator` class.
- `StringExtensionsShould.cs`: A class that contains unit tests for the `StringExtensions` class.

## How to Use

1. Clone the repository.
2. Open the solution in Visual Studio or your preferred code editor.
3. Run the tests in the `StringCalculatorShould.cs` and `StringExtensionsShould.cs` files to verify that everything is working correctly.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please create an issue or pull request.

## License
This project is licensed under the [MIT License](./LICENSE) - see the LICENSE file for details.

## Author:
This project was developed by [Mohammad Othman](https://github.com/OthmanMohammad).

