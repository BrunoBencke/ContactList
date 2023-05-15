using ContactList.Core.Utils;

namespace BalancedSupportsTests
{
    public class BalancedSupportsTests
    {
        [Theory]
        [InlineData("(){}[]", true)]
        [InlineData("[{()}](){}", true)]
        [InlineData("[]{()", false)]
        [InlineData("[{)]", false)]
        public void TestVerifyBalancedSupports(string input, bool expectedOutput)
        {
            bool actualOutput = BalancedSupports.VerifyBalancedSupports(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}