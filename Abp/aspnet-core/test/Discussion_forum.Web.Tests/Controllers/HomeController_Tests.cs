using System.Threading.Tasks;
using Discussion_forum.Models.TokenAuth;
using Discussion_forum.Web.Controllers;
using Shouldly;
using Xunit;

namespace Discussion_forum.Web.Tests.Controllers
{
    public class HomeController_Tests: Discussion_forumWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}