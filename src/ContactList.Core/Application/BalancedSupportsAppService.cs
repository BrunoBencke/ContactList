using ContactList.Core.Utils;

namespace ContactList.Core.Application
{
    public class BalancedSupportsAppService
    {
        public static bool VerifyBalancedSupports(string text)
        {
            return BalancedSupports.VerifyBalancedSupports(text);
        }
    }
}
