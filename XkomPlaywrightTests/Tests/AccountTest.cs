using IPMCSeleniumTest.Helpers;
using IPMCSeleniumTest.Tests;
using NUnit.Framework;
using TrelloTestAutomation.Pages;

namespace TrelloTestAutomation.Tests
{
    public class AccountTest : BaseTest<AccountPage>
    {


        [Test]
        public async Task AddProductToFavorites_VerifyProductInFavoritesTab()
        {
            var searchPage = await NavigationBar.SearchForProduct(Configuration.GetAppSettings().AvailableProduct);
            await searchPage.AddProductToFavorites();
            await TestedPage.GoTo();
            string existingFavoriteProduct = await TestedPage.VerifyProductInFavoritesTab();
            Assert.AreEqual(Configuration.GetAppSettings().AvailableProduct, existingFavoriteProduct);
        }
    }
}
