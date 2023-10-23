using IPMCSeleniumTest.Helpers;
using IPMCSeleniumTest.Pages;
using Microsoft.Playwright;

namespace TrelloTestAutomation.Pages
{
    public class LoginPage : BasicPage
    {
        public LoginPage(IPage page) : base(page)
        {
        }

        public async Task<bool> CheckIfNotLogged()
        {
            return await IsElementExists("//h2[contains(text(),'Zaloguj się')]");
        }

        public async Task LoginByCorrectCredentials()
        {
            await SetText("(//input[@placeholder='E-mail lub login'])[1]", Configuration.GetAppSettings().Credentials.Login);
            await SetText("//input[@placeholder='Hasło']", Configuration.GetAppSettings().Credentials.Password);
            await Click("//button[@type='submit']");
        }
    }
}
