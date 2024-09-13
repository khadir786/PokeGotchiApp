using System.Text.Json.Serialization;
using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class Gummi : Food
    {
        public GummiColour Colour { get; set; }

        [JsonConstructor]
        public Gummi(GummiColour colour)
        {
            Name = $"{colour} Gummi";
            Image = $"images/items/food/gummi/{colour.ToString().ToLower()}-gummi.png";
            BuyValue = 25;
            SellValue = 18;
            NutritionValue = 15;
            Colour = colour;

            HappinessValue = 10;
            JoyValue = 5;
            EnergyValue = 10;
            ExpValue = 3;

        }

       
    }
}
