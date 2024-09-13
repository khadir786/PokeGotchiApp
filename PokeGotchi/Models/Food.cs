using PokeGotchi.Models.Interfaces;

namespace PokeGotchi.Models
{
    public abstract class Food : Item, IConsumable
    {
        public int NutritionValue { get; set; }

        public abstract void Consume(Partner partner);

    }
}
