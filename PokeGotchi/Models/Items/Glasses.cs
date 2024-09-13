using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items
{
    public class Glasses : Toy
    {
        [JsonConstructor]
        public Glasses()
        {
            Name = "Glasses";
            Image = "images/items/Glasses.png";
            BuyValue = 18;
            SellValue = 12;

            HappinessValue = 10;
            JoyValue = 6;
            ExhaustionValue = 8;
            ExpValue = 19;
        }
    }
}
