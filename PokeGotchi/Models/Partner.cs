using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models;

public class Partner : Pokemon
{
    public string Name { get; set; } = "Riolu";
    public Dictionary<Stats, int> Stats { get; set; } = new();
    public Mood CurrentMood { get; set; }

    public int GridRow { get; set; }
    public int GridColumn { get; set; }

    // animation state represents the path of a gif
    public string AnimationState { get; set; }

    public Partner()
    {
        this.Species = "Riolu";
        this.Name = "Riolu";
        this.GridRow = 0;
        this.GridColumn = 0;
        this.AnimationState = "images/animations/idle.gif";

        // can still have a random Happiness value if none is provided but also allow control over it if needed
        Stats[Enums.Stats.Happiness] = Random.Shared.Next(15, 30);
        Stats[Enums.Stats.Friendship] = 10;
        Stats[Enums.Stats.Hunger] = 60;
        Stats[Enums.Stats.Energy] = 55;

        // random starting mood between angry, playful and wary
        Mood[] possibleMoods = { Mood.Angry, Mood.Playful, Mood.Wary };
        int randomIdx = Random.Shared.Next(possibleMoods.Length);
        this.CurrentMood = possibleMoods[randomIdx];
        
    }

    public override void Walk(Direction direction, int numRows, int numColumns)
    {
        IsMoving = true;

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

    public void SetIdle()
    {
        IsMoving = false;
        AnimationState = "images/animations/idle.gif";
    }

    public void Eat(Food food)
    {
        Stats[Enums.Stats.Hunger] += food.NutritionValue;
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
