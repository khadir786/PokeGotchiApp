namespace PokeGotchi.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Image { get; set; } // image path
        public int BuyValue { get; set; }
        public int SellValue { get; set; }


    }
}