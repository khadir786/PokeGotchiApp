using System.Security.AccessControl;
using PokeGotchi.Models.Enums;
using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items.Foods
{
    public class GoldenApple : Food
    {
        [JsonConstructor]
        public GoldenApple()
        {
            Name = "Golden Apple";
            Image = "images/items/food/normal/golden-apple.png";
            BuyValue = 50;
            SellValue = 25;
            NutritionValue = 50;
            HappinessValue = 20;
            JoyValue = 15;
            ExpValue = 15;
            EnergyValue = 30;
        }

    }

}