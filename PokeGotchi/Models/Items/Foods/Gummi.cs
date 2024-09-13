using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Items.Foods
{
    public class Gummi : Food
    {
        public GummiColour Colour { get; set; }

        public Gummi(GummiColour colour)
        {
            this.Name = $"{colour} Gummi";
            this.Image = $"images/items/food/gummis/{colour.ToString().ToLower()}-gummi.png"; 
            this.BuyValue = 50; 
            this.SellValue = 25;
            this.NutritionValue = 20; // Example nutrition value, adjust as needed
            this.Colour = colour;
        }

        public override void Consume(Partner partner)
        {
            if (partner.FavouriteGummi.Colour == this.Colour)
            {
                partner.Stats[Enums.Stats.Happiness] += 30; 
            }
            else
            {
                partner.Stats[Enums.Stats.Happiness] += 5; 
            }

            partner.Stats[Enums.Stats.Hunger] += NutritionValue; 
        }
    }
}
