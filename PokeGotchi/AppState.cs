using Blazored.LocalStorage;
using System.ComponentModel;
using PokeGotchi.Models;
using PokeGotchi.Utils;

namespace PokeGotchi
{
    public class AppState : INotifyPropertyChanged
    {
        private string _gameScreen = "PLAY";
        public string GameScreen
        {
            get => _gameScreen;
            set
            {
                if (_gameScreen != value)
                {
                    _gameScreen = value;
                    OnPropertyChanged(nameof(GameScreen));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // SAVE DATA - blazored local storage is used for saving and loading data
        public SaveData SaveData { get; set; } = new SaveData();

        private readonly ILocalStorageService _localStorage;

        public AppState(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadSaveDataAsync()
        {
            var save = await _localStorage.GetItemAsync<SaveData>("pokeGotchiSave");
            if (save != null)
            {
                // if save data exists, load it
                SaveData = save;
            }
            else
            {
                // ...otherwise, initialise with default properties
                SaveData = new SaveData
                {
                    PartnerPokemon = new Partner()
                };
                await SaveGameDataAsync(); // Save the default data
            }
        }

        public async Task SaveGameDataAsync()
        {
            await _localStorage.SetItemAsync("pokeGotchiSave", SaveData);
        }

        
    }
}