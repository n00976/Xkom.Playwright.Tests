using IPMCSeleniumTest.Helpers;
using IPMCSeleniumTest.Models;
using Microsoft.Playwright;

namespace IPMCSeleniumTest.Pages
{
    public abstract class BasicPage : Interfaces.IPage
    {

        public BasicPage(IPage page)
        {
            Page = page;
            _appSettings = Configuration.GetAppSettings();

        }
        protected AppSettings _appSettings;
        protected Microsoft.Playwright.IPage Page;
        protected IBrowser Browser;
        protected async Task Click(string selector) => await Page.ClickAsync(selector);
        protected async Task<bool> IsElementDisplayedAfterWaiting(string selector) => await Page.WaitForSelectorAsync(selector) != null;
        protected async Task<IElementHandle> LocateElement(string selector) => await Page.QuerySelectorAsync(selector);
        protected async Task SetText(string selector, string text) => await Page.FillAsync(selector, text);
        protected async Task ClickOnElementAfterWaiting(string selector) => await Page.ClickAsync(selector);
        protected async Task<string> GetTextOfElement(string selector) => await Page.InnerHTMLAsync(selector);
        protected async Task<bool> IsElementVisable(string selector)
        {
            return await Page.IsVisibleAsync(selector);
        }
        protected async Task<bool> IsElementExists(string selector)
        {
            try
            {
                await Page.WaitForSelectorAsync(selector, new() { State = WaitForSelectorState.Attached, Timeout = 3000 });

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task AcceptCookies()
        {
            if (await Page.IsVisibleAsync("//h3[contains(text(),'Dostosowujemy się do Ciebie')]"))
            {
                await Click("//button[contains(text(),'W porządku')]");
            }
        }

        public virtual async Task GoTo()
        {
            await Page.GotoAsync(_appSettings.HomePage);
        }

    }
}