using NUnit.Framework;
using POC.Apps.Login;

namespace POC
{
    public class Tests: TenprintLogin
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TenprintLogin()
        {
            TenprintAppsLogin(FIRST_USER);
         //   Assert.Pass("Passed successfully");
        }
    }
}