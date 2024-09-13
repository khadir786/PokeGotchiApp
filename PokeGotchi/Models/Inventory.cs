using System.Collections.Generic;

namespace PokeGotchi.Models
{
    public class Inventory
    {
        public List<Item> Items { get; set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        // Add an item to the inventory
        public void AddItem(Item item)
        {
            if (Items.Count < 8) // Inventory size is 4x2 = 8
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}