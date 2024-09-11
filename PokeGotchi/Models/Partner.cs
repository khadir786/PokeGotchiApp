using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models;

public class Partner : Pokemon
{
    public string Name { get; set; } = "Riolu";
    public Dictionary<string, int> Stats { get; set; } = new();

    private int _happiness;
    private int _friendship;
    private int _hunger;
    private int _energy;
    public Mood CurrentMood { get; set; }

    public int GridRow { get; set; }
    public int GridColumn { get; set; }

    public int Happiness
    {
        get => _happiness;
        set
        {
            _happiness = value;
            Stats["Happiness"] = _happiness;
        }
    }

    public int Friendship
    {
        get => _friendship;
        set
        {
            _friendship = value;
            Stats["Friendship"] = _friendship;
        }
    }

    public int Hunger
    {
        get => _hunger;
        set
        {
            _hunger = value;
            Stats["Hunger"] = _hunger;
        }
    }

    public int Energy
    {
        get => _energy;
        set
        {
            _energy = value;
            Stats["Energy"] = _energy;
        }
    }


    // animation state represents the path of a gif
    public string AnimationState { get; set; }

    public Partner(string species, string name, int gridRow, int gridColumn, int happiness = 0, int friendship = 10, int hunger = 60, int energy = 55)
    {
        this.Species = species;
        this.Name = name;
        this.GridRow = gridRow;
        this.GridColumn = gridColumn;
        
        // can still have a random Happiness value if none is provided but also allow control over it if needed
        this.Happiness = happiness == 0 ? Random.Shared.Next(15, 30) : happiness;
        this.Friendship = friendship;
        this.Hunger = hunger;
        this.Energy = energy;

        // Populate the Stats dictionary with initial values
        Stats["Happiness"] = this.Happiness;
        Stats["Friendship"] = this.Friendship;
        Stats["Hunger"] = this.Hunger;
        Stats["Energy"] = this.Energy;

        Mood[] possibleMoods = { Mood.Angry, Mood.Playful, Mood.Wary };
        int randomIdx = Random.Shared.Next(possibleMoods.Length);
        this.CurrentMood = possibleMoods[randomIdx];
        this.AnimationState = "images/animations/idle.gif";

    }


    public override void Walk(Direction direction, int numRows, int numColumns)
    {
        // Move the partner by adjusting gridRow and gridColumn based on the direction
        switch (direction)
        {
            case Direction.Up:
                if (GridRow > 0) GridRow--;
                AnimationState = "images/animations/walks/walk-up.gif";
                break;
            case Direction.Down:
                if (GridRow < numRows - 1) GridRow++;
                AnimationState = "images/animations/walks/walk-down.gif";
                break;
            case Direction.Left:
                if (GridColumn > 0) GridColumn--;
                AnimationState = "images/animations/walks/walk-left.gif";
                break;
            case Direction.Right:
                if (GridColumn < numColumns - 1) GridColumn++;
                AnimationState = "images/animations/walks/walk-right.gif";
                break;
            case Direction.UpRight:
                if (GridRow > 0) GridRow--;
                if (GridColumn < numColumns - 1) GridColumn++;
                AnimationState = "images/animations/walks/walk-up-right.gif";
                break;
            case Direction.UpLeft:
                if (GridRow > 0) GridRow--;
                if (GridColumn > 0) GridColumn--;
                AnimationState = "images/animations/walks/walk-up-left.gif";
                break;
            case Direction.DownRight:
                if (GridRow < numRows - 1) GridRow++;
                if (GridColumn < numColumns - 1) GridColumn++;
                AnimationState = "images/animations/walks/walk-down-right.gif";
                break;
            case Direction.DownLeft:
                if (GridRow < numRows - 1) GridRow++;
                if (GridColumn > 0) GridColumn--;
                AnimationState = "images/animations/walks/walk-down-left.gif";
                break;
        }
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
