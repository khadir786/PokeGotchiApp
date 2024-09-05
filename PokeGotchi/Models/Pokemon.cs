using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models
{
    public abstract class Pokemon : IMoveable
    {
        public string Species { get; set; }
        public bool isMoving;

        public abstract void Walk(int x, int y, Direction direction);

        public abstract void Run(int x, int y, Direction direction);
    }
}
