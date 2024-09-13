using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class Gummi : Food
    {
        public GummiColour Colour { get; set; }

        public Gummi(GummiColour colour)
        {
            this.Name = $"{colour} Gummi";
            this.Image = $"images/items/food/gummi/{colour.ToString().ToLower()}-gummi.png";
            this.BuyValue = 25;
            this.SellValue = 18;
            this.NutritionValue = 20; // Example nutrition value, adjust as needed
            this.Colour = colour;
        }

        public override void Consume(Partner partner)
        {
            if (partner.FavouriteGummi.Colour == this.Colour)
            {
                partner.IncreaseStat(Stats.Happiness, 35);
            }
            else if (partner.HatedGummi.Colour == this.Colour)
            {
                partner.IncreaseStat(Stats.Happiness, 20);
            }
            else
            {
                partner.IncreaseStat(Stats.Happiness, 12);
            }

            partner.IncreaseStat(Stats.Hunger, 12);
        }
    }
}
