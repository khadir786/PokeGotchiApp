using PokeGotchi.Models.Enums;
using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items.Foods
{
    public class GrimerFood : Food
    {
        [JsonConstructor]
        public GrimerFood()
        {
            Name = "Grimer Food";
            Image = "images/items/food/normal/grimer-food.png";
            BuyValue = 6;
            SellValue = 2;
            NutritionValue = 25;
            HappinessValue = 15;
            JoyValue = 8;
            ExpValue = 8;
            EnergyValue = 24;
        }
    }

}