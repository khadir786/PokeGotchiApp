using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models;

public class Partner : Pokemon
{
    public string Name { get; set; } = "Riolu";
    public int XPos { get; set; }
    public int YPos { get; set; }
    public int Happiness { get; set; }
    public int Friendship { get; set; }
    public int Hunger { get; set; }

    public Partner(string species, string name, int xPos, int yPos, int happiness = 0, int friendship = 10, int hunger = 60) : base()
    {
        this.Species = species;
        this.Name = name;
        this.XPos = xPos;
        this.YPos = yPos;
        // can still have a random Happiness value if none is provided but also allow control over it if needed
        this.Happiness = happiness == 0 ? Random.Shared.Next(15, 30) : happiness;
        this.Friendship = friendship;
        this.Hunger = hunger;
    }


    public override void Walk(int x, int y, Direction direction)
    {
        throw new NotImplementedException();
    }

    public override void Run(int x, int y, Direction direction)
    {
        throw new NotImplementedException();
    }


    public void Eat(Food food)
    {
        Hunger += food.NutritionValue;
    }

    public void Yawn()
    {
        throw new NotImplementedException();
    }
    
    public void Tumble()
    {
        throw new NotImplementedException();
    }
    
    public void Fall()
    {
        throw new NotImplementedException();
    }



}