namespace PokeGotchi.Models.Interfaces
{
    public interface IPickUpable
    {
        public void PickUp();
        public void PlaceDown(int gridRow, int gridColumn);
        
    }
}
