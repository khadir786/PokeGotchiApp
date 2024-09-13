using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items
{
    public class Ribbon : Item
    {
        [JsonConstructor]
        public Ribbon()
        {
            this.Name = "Ribbon";
            this.Image = "images/items/Ribbon.png";
            this.BuyValue = 24;
            this.SellValue = 18;
        }
    }
}
