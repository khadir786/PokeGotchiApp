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
            partner.Stats[Enums.Stats.Hunger] += NutritionValue;

            partner.Stats[Enums.Stats.Happiness] += 5;

            partner.Stats[Stats.Friendship] += 3;

            partner.Stats[Stats.Experience] += 3;

            partner.Stats[Stats.Energy] += 10;


        }
    }

}
