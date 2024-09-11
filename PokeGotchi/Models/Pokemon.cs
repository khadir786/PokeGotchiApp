using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models
{
    public abstract class Pokemon : IMoveable
    {
        public string Species { get; set; }
        public bool isMoving;

        public abstract void Walk(Direction direction, int numRows, int numColumns);

    }
}
