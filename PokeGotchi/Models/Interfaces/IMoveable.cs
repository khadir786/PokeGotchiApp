using PokeGotchi.Models.Enums;

namespace PokeGotchi.Models.Interfaces
{
    public interface IMoveable
    {
        public void Walk(Direction direction, int numRows, int numColumns);
    }
}
