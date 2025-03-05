using System.Globalization;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GIVEN_two_positive_numbers_WHEN_operation_plus_RETURN_positive()
        {
            //Arrange
            String input = "+ 2 3";
            int actual, expected = 5;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);  
        }

        [Fact]
        public void GIVEN_two_positive_numbers_WHEN_operation_minus_RETURN_positive()
        {
            //Arrange
            String input = "- 8 3";
            int actual, expected = 5;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GIVEN_two_positive_numbers_WHEN_operation_multiply_RETURN_positive()
        {
            //Arrange
            String input = "* 8 3";
            int actual, expected = 24;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GIVEN_two_positive_numbers_WHEN_operation_division_RETURN_positive()
        {
            //Arrange
            String input = "/ 8 4";
            int actual, expected = 2;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("- + 7 2 3")]
        [InlineData("- 14 + 5 3")]
        public void GIVEN_three_positive_numbers_WHEN_operation_plus_RETURN_positive(string input)
        {
            //Arrange
            int actual, expected = 6;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("+ - 7 7 2")]
        [InlineData("- 7 + 2 3")]
        public void GIVEN_three_positive_numbers_WHEN_operation_minus_RETURN_positive(string input)
        {
            //Arrange
            int actual, expected = 2;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("- * 7 2 4")]
        [InlineData("* 2 + 2 3")]
        public void GIVEN_three_positive_numbers_WHEN_operation_multiply_RETURN_positive(string input)
        {
            //Arrange
            int actual, expected = 10;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("- / 8 2 4")]
        [InlineData("- 2 / 10 5")]
        public void GIVEN_three_positive_numbers_WHEN_operation_division_RETURN_positive(string input)
        {
            //Arrange
            int actual, expected = 0;
            Calc c = new Calc();

            // Act
            actual = c.calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}