using System.Text.Json.Serialization;

namespace PokeGotchi.Models.Items
{
    public class Ball : Toy
    {
        [JsonConstructor]
        public Ball()
        {
            Name = "Ball";
            Image = "images/items/Ball.png";
            BuyValue = 20;
            SellValue = 15;

            HappinessValue = 20;
            JoyValue = 8;
            ExhaustionValue = 12;
            ExpValue = 12;

        }
    }
}
