using IPMCSeleniumTest.Pages;
using Microsoft.Playwright;

namespace TrelloTestAutomation.Pages
{
    public class SearchPage : BasicPage
    {
        public SearchPage(IPage page) : base(page)
        {

        }

        public async Task<int> GetAmountOfProducts()
        {
            var elements = await Page.QuerySelectorAllAsync("//div[@class='sc-1s1zksu-0 dzLiED sc-162ysh3-1 irFnoT']");
            var count = elements.Count;
            return count;
        }

        public async Task AddProductToFavorites()
        {
            await ClickOnElementAfterWaiting("//div[@class='sc-2ride2-0 dwsfIN sc-1yu46qn-4 gyHdpL']");
            if (await IsElementVisable("//div[@class='sc-1s1zksu-0 ecpleP sc-14h089p-0 gybZZY sc-8ngj2v-1 doqQAm']//button[@title='Zapisz na liście']"))
            {
                await ClickOnElementAfterWaiting("//div[@class='sc-1s1zksu-0 ecpleP sc-14h089p-0 gybZZY sc-8ngj2v-1 doqQAm']//button[@title='Zapisz na liście']");
                await ClickOnElementAfterWaiting("(//button[@class='sc-15ih3hi-0 sc-14uv5p9-4 fSDviF'])[1]");
            }


        }
    }
}
