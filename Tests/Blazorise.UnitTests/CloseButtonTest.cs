﻿#region Using directives
using BasicTestApp.Client;
using Blazorise.UnitTests.Infrastructure;
using Blazorise.UnitTests.Infrastructure.ServerFixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Xunit.Abstractions;
using DevHostServerProgram = BasicTestApp.Server.Program;
#endregion

namespace Blazorise.UnitTests
{
    public class CloseButtonTest : BasicTestAppTestBase
    {
        public CloseButtonTest( BrowserFixture browserFixture,
            ToggleExecutionModeServerFixture<DevHostServerProgram> serverFixture,
            ITestOutputHelper output )
            : base( browserFixture, serverFixture, output )
        {
            Navigate( ServerPathBase, noReload: !serverFixture.UsingAspNetHost );
            MountTestComponent<CloseButtonComponent>();
        }

        [Fact]
        public void CanRaiseCallback()
        {
            var paragraph = Browser.FindElement( By.Id( "close-button-event" ) );
            var button = paragraph.FindElement( By.TagName( "button" ) );
            var result = paragraph.FindElement( By.Id( "close-button-event-result" ) );

            WaitAssert.Equal( "0", () => result.Text );

            button.Click();
            WaitAssert.Equal( "1", () => result.Text );

            button.Click();
            WaitAssert.Equal( "2", () => result.Text );
        }
    }
}
