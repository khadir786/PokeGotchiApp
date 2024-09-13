using PokeGotchi.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PokeGotchi.Models.Items.Foods
{
    public class Apple : Food
    {
        public Apple()
        {
            Name = "Apple";
            Image = "images/items/food/apple.png";
            BuyValue = 10;
            SellValue = 5;
            NutritionValue = 15; 
        }

        public override void Consume(Partner partner)
        {
            partner.IncreaseStat(Stats.Hunger, NutritionValue);

            partner.IncreaseStat(Stats.Happiness, 5);

            partner.IncreaseStat(Stats.Friendship, 3);
            
            partner.IncreaseStat(Stats.Experience, 3);

            partner.IncreaseStat(Stats.Energy, 10);

        }
    }

}
