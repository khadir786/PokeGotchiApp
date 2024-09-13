namespace PokeGotchi.Models.Items
{
    public class Ball : Item
    {
        public Ball()
        {
            this.Name = "Ball";
            this.Image = "images/items/Ball.png";
            this.BuyValue = 20;
            this.SellValue = 15;
        }
    }
}
