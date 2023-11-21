namespace ComarchCwiczenia.Tests
{
    public class CalculatorTests
    {
        Calculator calclulator;

        [SetUp]
        public void Setup()
        {
            calclulator = new Calculator();
        }

        [Test]
        [TestCase(2, 3)]
        public void AddShouldReturnCorrectSum(int x, int y)
        {
            //Arrange
            int expected = x + y;

            //Act
            int actual = calclulator.Add(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2)]
        [TestCase(10, 20)]
        [TestCase(0, 0)]
        [TestCase(100, 0)]
        public void SubtractShouldReturnCorrectResult(int x, int y)
        {
            //Arrange
            int expected = x - y;

            //Act
            int actual = calclulator.Subtract(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2)]
        [TestCase(10, 20)]
        [TestCase(0, 0)]
        [TestCase(100, 0)]
        public void MultiplyShouldReturnCorrectResult(int x, int y)
        {
            //Arrange
            int expected = x * y;

            //Act
            int actual = calclulator.Multiply(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2)]
        [TestCase(10, 20)]
        [TestCase(0, 1)]
        [TestCase(100, 1)]
        public void DividyShouldReturnCorrectResult(int x, int y)
        {
            //Arrange
            float expected = x / (float)y;

            //Act
            float actual = calclulator.Divide(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(3, 2)]
        [TestCase(10, 20)]
        [TestCase(0, 1)]
        [TestCase(100, 1)]
        public void ModuloShouldReturnCorrectResult(int x, int y)
        {
            //Arrange
            float expected = x % (float)y;

            //Act
            float actual = calclulator.Modulo(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ModuloShouldThrowExceptionWhenYEqual0()
        {
            //Arrange
            int x = 1; int y = 0;

            //Assert
            Assert.Throws<DivideByZeroException>(() => calclulator.Modulo(x, y));
        }

    }
}