using PokeGotchi.Models.Enums;
using PokeGotchi.Models.Items.Foods;

namespace PokeGotchi.Models
{
    public class Shop
    {
        private const int MaxItems = 4;

        public List<Item> CurrentItems { get; set; }
        Random random = new Random();


        public Shop()
        {
            CurrentItems = new List<Item>();
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

        private Item GetRandomItem()
        {
            // Add logic to randomly select an item to populate the shop
            Array gummiColors = Enum.GetValues(typeof(GummiColour));

            // set the favourite gummi
            GummiColour colour = (GummiColour)gummiColors.GetValue(random.Next(gummiColors.Length));
            return new Gummi(colour);
        }

        public void CycleItems()
        {
            LoadRandomItems(); // Reloads the shop with new items
        }
    }
}