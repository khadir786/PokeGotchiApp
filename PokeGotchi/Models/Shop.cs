using PokeGotchi.Models.Enums;
using PokeGotchi.Models.Items;
using PokeGotchi.Models.Items.Foods;

namespace PokeGotchi.Models
{
    public class Shop
    {
        private const int MaxItems = 4;

        public List<Item> CurrentItems { get; set; }
        public List<Item> Stock { get; set; }
        Random random = new Random();


        public Shop()
        {
            CurrentItems = new List<Item>();
            Stock = new List<Item>();
            LoadStock(Stock);

            LoadRandomItems();

        }

        public void LoadRandomItems()
        {
            CurrentItems.Clear();
            for (int i = 0; i < MaxItems; i++)
            {
                CurrentItems.Add(GetRandomItem());
            }
        }

        public void LoadStock(List<Item> stock)
        {
            foreach (var gummiColour in Enum.GetValues(typeof(GummiColour)))
            {
                stock.Add(new Gummi((GummiColour)gummiColour));
            }
            stock.Add(new Ball());
            stock.Add(new Banana());
            stock.Add(new Apple());
            stock.Add(new GoldenApple());
            stock.Add(new Glasses());
            stock.Add(new Ribbon());
            stock.Add(new GrimerFood());

        }

        private Item GetRandomItem()
        {
            return Stock[random.Next(Stock.Count)];
        }

        public void CycleItems()
        {
            LoadRandomItems(); // Reloads the shop with new items
        }
    }
}