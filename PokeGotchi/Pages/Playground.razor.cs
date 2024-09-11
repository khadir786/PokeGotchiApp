﻿using Microsoft.JSInterop;
using PokeGotchi.Models.Enums;
using PokeGotchi.Models;
using System.Text.Json;

namespace PokeGotchi.Pages
{
    public partial class Playground
    {
        private Partner PartnerPokemon;
        private int cellSize = 50;
        private int numOfRows;
        private int numOfColumns;

        private DotNetObjectReference<Playground> dotNetHelper;

        protected override void OnInitialized()
        {
            // load partner Pokémon from AppState
            PartnerPokemon = GameState.SaveData.PartnerPokemon;
            dotNetHelper = DotNetObjectReference.Create(this); // needed for resize observer
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // ensure the resize observer is attached after the component is rendered
                await JS.InvokeVoidAsync("observeElementSize", "playground-container", dotNetHelper);
            }
        }

        [JSInvokable]
        public void OnSizeChanged(int width, int height)
        {
            CalculateGridDimensions(width, height);

            // re-render after size changes
            StateHasChanged();
        }

        private void CalculateGridDimensions(int width, int height)
        {
            numOfRows = height / cellSize;
            numOfColumns = width / cellSize;
        }

        private async Task MovePartner(Direction direction)
        {
            PartnerPokemon.Walk(direction, numOfRows, numOfColumns); // pass grid bounds to limit movement
            SaveAndRefresh();

            await Task.Delay(300);
            GoIdle();
        }

        private void GoIdle()
        {
            PartnerPokemon.AnimationState = "images/animations/idle.gif";
            SaveAndRefresh();
        }

        private async Task ExportData()
        {
            // serialize the PartnerPokemon object to json
            var jsonSaveData = JsonSerializer.Serialize(GameState.SaveData);

            // js function for triggering the downloadFile function (defined in index.html)
            await JS.InvokeVoidAsync("downloadFile", "pokeGotchiSaveData.json", jsonSaveData);
        }

        private void SaveAndRefresh()
        {
            // refresh the UI and save game data
            StateHasChanged();
            GameState.SaveGameDataAsync();
        }

        public void Dispose()
        {
            // cleanup the observer when the component is destroyed
            JS.InvokeVoidAsync("unobserveElementSize", "playground-container");
            dotNetHelper?.Dispose();
        }
    }
}
