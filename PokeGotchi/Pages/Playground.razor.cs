using Microsoft.JSInterop;
using PokeGotchi.Models.Enums;
using PokeGotchi.Models;
using System.Text.Json;

namespace PokeGotchi.Pages
{
    public partial class Playground
    {
        private Partner PartnerPokemon;
        private Player Player;
        private int cellSize = 50;
        private int numOfRows;
        private int numOfColumns;
        private bool autoMoveEnabled = true; // random autonomous movement toggle
        private bool manualMoveInProgress = false; // flag to pause autonomous movement during manual movement

        private DotNetObjectReference<Playground> dotNetHelper;
        private CancellationTokenSource _movementCancellationTokenSource;

        protected override void OnInitialized()
        {
            // load partner Pokémon from AppState
            PartnerPokemon = GameState.SaveData.PartnerPokemon;
            Player = GameState.SaveData.Player;
            dotNetHelper = DotNetObjectReference.Create(this); // needed for resize observer
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            StartAutonomousMovement();
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

        // method for when the player clicks on a cell to direct the partner to go there
        private async Task MoveTowardsTarget(int targetRow, int targetCol)
        {
            // cancel any ongoing movement if the player clicks on another cell
            _movementCancellationTokenSource?.Cancel();

            manualMoveInProgress = true;

            // create a new cancellation token source for the new movement task
            _movementCancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _movementCancellationTokenSource.Token;

            Console.WriteLine($"Target row: {targetRow}, Target col: {targetCol}");

            try
            {
                // loop until partner reaches target row and column OR the movement is cancelled
                while ((PartnerPokemon.GridRow != targetRow || PartnerPokemon.GridColumn != targetCol) &&
                       !cancellationToken.IsCancellationRequested)
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
            finally
            {
                manualMoveInProgress = false;
            }
        }

        private async Task StartAutonomousMovement()
        {
            Random random = new Random();
            while (autoMoveEnabled)
            {
                // wait for a random amount of time before the next move (between 1-3 seconds)
                await Task.Delay(random.Next(1000, 3000));

                // dont do autonomous movement if manual movement is in progress
                if (manualMoveInProgress) continue;

                // choose a random direction to move
                Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction)); // List of directions from direction enum
                Direction randomDirection = directions[random.Next(directions.Length)];

                // move partner in the chosen direction, a random number of steps (1-3 steps)
                int steps = random.Next(1, 4);
                for (int i = 0; i < steps; i++)
                {
                    if (!manualMoveInProgress)
                    {
                        PartnerPokemon.Walk(randomDirection, numOfRows, numOfColumns);
                        StateHasChanged();
                        await Task.Delay(300); // step delay
                    }
                }

                // after moving, set the partner to idle for a random duration (2-5 seconds)
                PartnerPokemon.SetIdle();
                StateHasChanged();
                await Task.Delay(random.Next(2000, 5000));
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
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonSaveData = JsonSerializer.Serialize(GameState.SaveData, options);

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
