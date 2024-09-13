using System.Text.Json.Serialization;

namespace PokeGotchi.Models
{
    public class Item
    {
        [JsonConstructor]
        public Item() { }

        public string Name { get; set; }
        public string Image { get; set; } // image path
        public int BuyValue { get; set; }
        public int SellValue { get; set; }


    }
}