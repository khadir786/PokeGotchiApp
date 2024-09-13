using PokeGotchi.Models.Interfaces;

namespace PokeGotchi.Models.Items
{
    public abstract class Food : Item, IConsumable
    {
        public int NutritionValue { get; set; }
        public int HappinessValue { get; set; }
        public int JoyValue { get; set; }
        public int EnergyValue { get; set; }
        public int ExpValue { get; set; }

        public void Consume()
        {
            Console.WriteLine($"{Name} was consumed");
        }

    }
}
