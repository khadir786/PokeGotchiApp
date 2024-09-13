using PokeGotchi.Models.Interfaces;

namespace PokeGotchi.Models.Items
{
    public abstract class Toy : Item, IPlayable
    {
        public int HappinessValue { get; set; }
        public int JoyValue { get; set; }
        public int ExhaustionValue { get; set; }
        public int ExpValue { get; set; }

        public void Play()
        {
            Console.WriteLine($"Played with {Name}");
        }
    }
}
