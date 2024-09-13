using System.Text.Json.Serialization;
using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class Banana : Food
    {
        [JsonConstructor]
        public Banana()
        {
            Name = "Banana";
            Image = "images/items/food/normal/banana.png";
            BuyValue = 12;
            SellValue = 6;
            NutritionValue = 20;
            HappinessValue = 8;
            JoyValue = 3;
            ExpValue = 3;
            EnergyValue = 15;
        }
    }

}