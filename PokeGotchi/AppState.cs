using System.ComponentModel;

namespace PokeGotchi
{
    // use events to observe game screen changes
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
    }
}