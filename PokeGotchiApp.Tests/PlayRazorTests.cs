using System;
using Bunit;
using Xunit;
using PokeGotchi.Pages;
using PokeGotchi;
using Moq;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace PokeGotchiApp.Tests
{
    public class PlayRazorTests : TestContext
    {
        [Fact]
        public void PlayButtonClick_ShouldNavigateToPlayground()
        {
            // Arrange: mock the ILocalStorageService
            var localStorageMock = new Mock<ILocalStorageService>();

            // register the mock ILocalStorageService
            Services.AddSingleton(localStorageMock.Object);

            // create an instance of AppState with the mocked ILocalStorageService
            // and register it in the test services
            var appState = new AppState(localStorageMock.Object);
            Services.AddSingleton(appState); 

            // render the play component
            var cut = RenderComponent<Play>();

            // Act: simulate the play button click
            cut.Find("#play-play-button").Click();

            // wait for the GameScreen state to change to "PLAYGROUND" because of Task.Delay(3000)
            cut.WaitForState(() => appState.GameScreen == "PLAYGROUND", TimeSpan.FromSeconds(4));

            // Assert: verify that GameScreen was set to "PLAYGROUND"
            Assert.Equal("PLAYGROUND", appState.GameScreen);
        }
    }
}