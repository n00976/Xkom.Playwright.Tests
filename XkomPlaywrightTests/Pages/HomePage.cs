using IPMCSeleniumTest.Helpers;
using IPMCSeleniumTest.Models;
using Microsoft.Playwright;

namespace IPMCSeleniumTest.Pages
{
    public class HomePage : BasicPage
    {
        public HomePage(IPage page) : base(page) { }


        public AppSettings AppSettings => _appSettings;

        public override async Task GoTo()
        {
            var homepage = Configuration.GetAppSettings().HomePage;
            await Page.GotoAsync(homepage);
        }

        internal async Task TestSmf()
        {
            await Click("//button[@class='sc-15ih3hi-0 sc-1p1bjrl-9 dRLEBj']");
            await Click("//a[@href='/konto']//div[@class='sc-fz2r3r-1 fXBMII']//span[@class='sc-1tblmgq-0 sc-1tblmgq-4 SBMEx sc-fz2r3r-2 cDltcV']//*[name()='svg']");
        }
    }
}
