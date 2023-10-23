using IPMCSeleniumTest.Pages;
using Microsoft.Playwright;
using TrelloTestAutomation.Models.Conts;

namespace TrelloTestAutomation.Pages
{
    public class AccountPage : BasicPage
    {
        public AccountPage(IPage page) : base(page)
        {
            _navigationBar = new NavigationBar(page);
        }

        private NavigationBar _navigationBar;

        public override async Task GoTo()
        {
            await base.GoTo();

            await AcceptCookies();

            var loginPage = await _navigationBar.GetLoginPage();

            bool isNotLogged = await loginPage.CheckIfNotLogged();
            if (isNotLogged == true)
            {
                await loginPage.LoginByCorrectCredentials();
            }

            var urlAccountPage = string.Join("/", _appSettings.HomePage, Subsite.Account);
            await Page.GotoAsync(urlAccountPage);
        }

        public async Task<string> VerifyProductInFavoritesTab()
        {
            await ClickOnElementAfterWaiting("//a[@class='sc-1h16fat-0 dNrrmO sc-1vth0-1 fzlvxz']");

            if (!await IsElementExists("//a[normalize-space()='Sigma S 70-200mm f/2.8 DG OS HSM Canon']"))
                return string.Empty;

            return await GetTextOfElement("//a[normalize-space()='Sigma S 70-200mm f/2.8 DG OS HSM Canon']");

        }
    }
}
