using System.Text.Json.Serialization;
using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class Apple : Food
    {
        [JsonConstructor]
        public Apple()
        {
            Name = "Apple";
            Image = "images/items/food/normal/apple.png";
            BuyValue = 10;
            SellValue = 5;
            NutritionValue = 15;
            HappinessValue = 5;
            JoyValue = 3;
            ExpValue = 3;
            EnergyValue = 10;


        }

        
    }

}
