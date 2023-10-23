using IPMCSeleniumTest.Pages;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IPMCSeleniumTest.Tests
{
    public abstract class BaseTest<T> where T : Interfaces.IPage
    {
        private IPage _page;
        [SetUp]
        public async Task Setup()
        {
            try
            {
                var playwright = await Playwright.CreateAsync();

                // Use 'chromium' or 'firefox' for different browsers.
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true, Args = new List<string>() { "--start-maximized" } }); // Set Headless to true for headless mode.

                var context = await browser.NewContextAsync();

                _page = await context.NewPageAsync();

                NavigationBar = new NavigationBar(_page);

                TestedPage = SelectTestedAppPage();

                await TestedPage.GoTo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        [TearDown]
        public async Task Teardown()
        {

            await _page.CloseAsync();
        }
        protected virtual T SelectTestedAppPage()
        {
            return (T)Activator.CreateInstance(typeof(T), _page);
        }
        protected T TestedPage { get; set; }
        protected NavigationBar NavigationBar { get; set; }
        private HomePage _homePage;

    }
}