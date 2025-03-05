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
    }
}