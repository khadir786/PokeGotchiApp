using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items
{
    public class Ribbon : Toy
    {
        [JsonConstructor]
        public Ribbon()
        {
            Name = "Ribbon";
            Image = "images/items/Ribbon.png";
            BuyValue = 24;
            SellValue = 18;

            HappinessValue = 17;
            JoyValue = 10;
            ExhaustionValue = 13;
            ExpValue = 13;
        }
    }
}
