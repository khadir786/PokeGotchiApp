using Microsoft.JSInterop;
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
        private CancellationTokenSource _movementCancellationTokenSource;

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
            PartnerPokemon.Walk(direction, numOfRows, numOfColumns);
            StateHasChanged();

            await Task.Delay(300);

            // set to idle once the movement is done
            PartnerPokemon.SetIdle();
            SaveAndRefresh();
        }

        private void MoveToTarget((int targetRow, int targetCol) target)
        {
            MoveTowardsTarget(target.targetRow, target.targetCol);
        }


        private async Task MoveTowardsTarget(int targetRow, int targetCol)
        {
            // cancel any ongoing movement if the player clicks on another cell
            _movementCancellationTokenSource?.Cancel();

            // create a new cancellation token source for the new movement task
            _movementCancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _movementCancellationTokenSource.Token;

            Console.WriteLine($"Target row: {targetRow}, Target col: {targetCol}");

            try
            {
                // loop until partner reaches target row and column OR the movement is cancelled
                while ((PartnerPokemon.GridRow != targetRow || PartnerPokemon.GridColumn != targetCol) && !cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine($"Moving to Row: {PartnerPokemon.GridRow}, Col: {PartnerPokemon.GridColumn}");

                    // prioritise diagonal movement first
                    if (PartnerPokemon.GridRow < targetRow && PartnerPokemon.GridColumn < targetCol)
                    {
                        PartnerPokemon.Walk(Direction.DownRight, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridRow < targetRow && PartnerPokemon.GridColumn > targetCol)
                    {
                        PartnerPokemon.Walk(Direction.DownLeft, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridRow > targetRow && PartnerPokemon.GridColumn < targetCol)
                    {
                        PartnerPokemon.Walk(Direction.UpRight, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridRow > targetRow && PartnerPokemon.GridColumn > targetCol)
                    {
                        PartnerPokemon.Walk(Direction.UpLeft, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridRow < targetRow)
                    {
                        PartnerPokemon.Walk(Direction.Down, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridRow > targetRow)
                    {
                        PartnerPokemon.Walk(Direction.Up, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridColumn < targetCol)
                    {
                        PartnerPokemon.Walk(Direction.Right, numOfRows, numOfColumns);
                    }
                    else if (PartnerPokemon.GridColumn > targetCol)
                    {
                        PartnerPokemon.Walk(Direction.Left, numOfRows, numOfColumns);
                    }

                    // re-render the component after every step to reflect movement
                    StateHasChanged();

                    // delay to simulate waking time
                    await Task.Delay(300, cancellationToken); // delay can be interrupted when cancelled 
                }

                if (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Target reached!!!!");
                    PartnerPokemon.SetIdle();
                    SaveAndRefresh();

                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Movement canceled.");
            }
        }

        private void GoIdle()
        {
            PartnerPokemon.SetIdle();
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
