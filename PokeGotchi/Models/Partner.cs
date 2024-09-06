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
    public string AnimationState { get; set; }

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
        // Update the XPos and YPos based on direction
        switch (direction)
        {
            case Direction.Up:
                YPos -= y;
                AnimationState = "images/animations/walks/walk-up.gif";
                break;
            case Direction.Down:
                YPos += y;
                AnimationState = "images/animations/walks/walk-down.gif";
                break;
            case Direction.Left:
                XPos -= x;
                AnimationState = "images/animations/walks/walk-left.gif";
                break;
            case Direction.Right:
                XPos += x;
                AnimationState = "images/animations/walks/walk-right.gif";
                break;
            case Direction.UpRight:
                XPos += x;
                YPos -= y;
                AnimationState = "images/animations/walks/walk-up-right.gif";
                break;
            case Direction.DownRight:
                XPos += x;
                YPos += y;
                AnimationState = "images/animations/walks/walk-down-right.gif";
                break;
            case Direction.UpLeft:
                XPos -= x;
                YPos -= y;
                AnimationState = "images/animations/walks/walk-up-left.gif";
                break;
            case Direction.DownLeft:
                XPos -= x;
                YPos += y;
                AnimationState = "images/animations/walks/walk-down-left.gif";
                break;
        }
    }

    public override void Run(int x, int y, Direction direction)
    {
        // Running logic could be a faster version of Walk
        Walk(x * 2, y * 2, direction);
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