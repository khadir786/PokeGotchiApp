using PokeGotchi.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PokeGotchi.Models.Items.Foods
{
    public class GoldenApple : Food
    {
        public GoldenApple()
        {
            Name = "Golden Apple";
            Image = "images/items/food/golden-apple.png";
            BuyValue = 50;
            SellValue = 25;
            NutritionValue = 50;
        }

        public override void Consume(Partner partner)
        {
            partner.Stats[Enums.Stats.Hunger] += NutritionValue;

            partner.Stats[Enums.Stats.Happiness] += 20;

            partner.Stats[Stats.Friendship] += 10;

            partner.Stats[Stats.Experience] += 10;

            partner.Stats[Stats.Energy] += 30;

        }
    }

}