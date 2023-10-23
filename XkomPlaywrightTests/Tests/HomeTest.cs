using IPMCSeleniumTest.Pages;
using IPMCSeleniumTest.Tests;
using NUnit.Framework;

namespace BasicSeleniumTest.Tests
{
    internal class HomeTest : BaseTest<HomePage>
    {
        protected override HomePage SelectTestedAppPage()
        {
            return NavigationBar.GetHomePage();
        }

        [Test]
        public async Task VerifyIfYouCan_GoOnPage()
        {
            Assert.IsTrue(true);

            await TestedPage.TestSmf();
        }

    }
}
