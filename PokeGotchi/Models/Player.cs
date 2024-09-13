namespace PokeGotchi.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public Inventory Inventory { get; set; }

        public Player()
        {
            Name = "Phil A. Solder";
            Money = 100;
            Inventory = new Inventory();
        }


    }
}
