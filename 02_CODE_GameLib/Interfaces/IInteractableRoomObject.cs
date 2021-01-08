namespace CODE_GameLib.Interfaces
{
    public interface IInteractableRoomObject
    {
        public int X { get; }
        public int Y { get; }

        public void OnEnter(IPlayer player);
    }
}
