using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items
{
    public class Glasses : Item
    {
        [JsonConstructor]
        public Glasses()
        {
            this.Name = "Glasses";
            this.Image = "images/items/Glasses.png";
            this.BuyValue = 18;
            this.SellValue = 12;
        }
    }
}
