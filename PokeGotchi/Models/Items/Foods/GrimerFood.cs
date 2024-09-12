﻿using PokeGotchi.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PokeGotchi.Models.Items.Foods
{
    public class GrimerFood : Food
    {
        public GrimerFood()
        {
            Name = "Grimer Food";
            Image = "images/items/food/grimer-food.png";
            BuyValue = 6;
            SellValue = 2;
            NutritionValue = 25;
        }

        public override void Consume(Partner partner)
        {
            partner.Stats[Enums.Stats.Hunger] += NutritionValue;

            partner.Stats[Enums.Stats.Happiness] -= 15;

            partner.Stats[Stats.Friendship] -= 8;

            partner.Stats[Stats.Experience] += 8;

            partner.Stats[Stats.Energy] += 15;

        }
    }

}