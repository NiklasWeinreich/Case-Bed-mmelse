using Bunit;
using Bunit.TestDoubles;
using H4SoftwareTest.Components.Account.Pages;
using H4SoftwareTest.Components.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace H4SoftwareTestTestProject;

public class AuthenticationTest
{
    [Fact]
    public void AuthenticationView()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();

        //Assert
        cut.MarkupMatches("<h1>Hello, world!</h1>\r\n<h2>You are NOT admin</h2>\r\n<br/>");
    }

    [Fact]
    public void AuthenticationCode()
    {
        //Arrange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.Equal(homeObj._isAuthenticated, true);
    }


}