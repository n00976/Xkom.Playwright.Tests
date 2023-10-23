using Microsoft.Playwright;
using TrelloTestAutomation.Pages;

namespace IPMCSeleniumTest.Pages
{
    public class NavigationBar : BasicPage
    {
        private IPage _page;
        public NavigationBar(IPage page) : base(page)
        {
            _page = page;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(_page);
        }

        public async Task<SearchPage> SearchForProduct(string productName)
        {
            await IsElementDisplayedAfterWaiting("//input[@placeholder='Czego szukasz?']");
            await SetText("//input[@placeholder='Czego szukasz?']", productName);
            await Click("//button[@class='sc-1p0xkzn-7 ihVVcs']");
            return new SearchPage(_page);
        }

        public async Task<LoginPage> GetLoginPage()
        {
            await Click("//a[@href='/konto']");
            return new LoginPage(_page);
        }
    }
}
