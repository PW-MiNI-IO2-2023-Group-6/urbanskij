namespace LabTDD.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var res = StringCalculator.Calculate(string.Empty);
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("42", 42)]
        [InlineData("3", 3)]
        public void StringWithNumberReturnsItsValue(string str, int expected)
        {
            var res = StringCalculator.Calculate(str);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("12,48", 60)]
        [InlineData("98,-3", 95)]
        public void StringNumbersSeparatedWithCommaReturnSum(string str, int expected)
        {
            var res = StringCalculator.Calculate(str);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("12\n48", 60)]
        [InlineData("98\n-3", 95)]
        public void StringNumbersInLinesReturnSum(string str, int expected)
        {
            var res = StringCalculator.Calculate(str);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("12\n48,9,16", 85)]
        [InlineData("-32\n0,12\n48,9,16", 53)]
        public void ManyStringNumbersSepartedWithCommasOrNewlinesReturnSum(string str, int expected)
        {
            var res = StringCalculator.Calculate(str);
            Assert.Equal(expected, res);
        }


        [Theory]
        [InlineData("12\n1048,9,16", 37)]
        [InlineData("-32\n0,1200\n48,9,16", 41)]
        [InlineData("-32\n0,1001\n48,9,16", 41)]
        [InlineData("1000", 1000)]
        [InlineData("5000", 0)]
        public void ManyStringNumbersSepartedWithCommasOrNewlinesIgnoringLargeNumbersReturnSum(string str, int expected)
        {
            var res = StringCalculator.Calculate(str);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("12\n1048,9,16", 37)]
        [InlineData("//#\n-32#0,1200#48,9,16", 41)]
        [InlineData("// \n-32\n0,1001 48,9,16", 41)]
        [InlineData("// \n1000", 1000)]
        [InlineData("5000", 0)]
        public void ManyStringNumbersStartWithOptionalSeparatorReturnsSum(string str, int expected)
        {

        }
    }
}