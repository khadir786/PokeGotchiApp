using PokeGotchi.Models.Enums;
using PokeGotchi.Models.Interfaces;

namespace PokeGotchi.Models
{
    public abstract class Pokemon : IMoveable, IPickUpable
    {
        public string Species { get; set; }
        public bool IsMoving;

        public abstract void Walk(Direction direction, int numRows, int numColumns);

        public abstract void PickUp();
        public abstract void PlaceDown(int gridRow, int gridColumn);
    }
}
