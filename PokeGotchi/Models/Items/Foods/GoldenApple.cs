using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class GoldenApple : Food
    {
        public GoldenApple()
        {
            Name = "Golden Apple";
            Image = "images/items/food/normal/golden-apple.png";
            BuyValue = 50;
            SellValue = 25;
            NutritionValue = 50;
        }

        public override void Consume(Partner partner)
        {
            partner.IncreaseStat(Stats.Hunger, NutritionValue);

            partner.IncreaseStat(Stats.Happiness, 20);

            partner.IncreaseStat(Stats.Friendship, 10);

            partner.IncreaseStat(Stats.Experience, 15);

            partner.IncreaseStat(Stats.Energy, 30);

        }

    }

}