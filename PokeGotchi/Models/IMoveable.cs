using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models
{
    public interface IMoveable
    {
        public void Walk(int x, int y, Direction direction);
        public void Run(int x, int y, Direction direction);
    }
}
