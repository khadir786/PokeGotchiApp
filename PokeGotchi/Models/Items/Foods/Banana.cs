using PokeGotchi.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PokeGotchi.Models.Items.Foods
{
    public class Banana : Food
    {
        public Banana()
        {
            Name = "Banana";
            Image = "images/items/food/banana.png";
            BuyValue = 12;
            SellValue = 6;
            NutritionValue = 20;
        }
        public override void Consume(Partner partner)
        {
            partner.IncreaseStat(Stats.Hunger, NutritionValue);

            partner.IncreaseStat(Stats.Happiness, 8);

            partner.IncreaseStat(Stats.Friendship, 3);

            partner.IncreaseStat(Stats.Experience, 3);

            partner.IncreaseStat(Stats.Energy, 15);

        }
    }

}