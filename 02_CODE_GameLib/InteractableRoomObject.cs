using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public abstract class InteractableRoomObject : IInteractableRoomObject
    {
        public int X { get; }
        public int Y { get; }

        protected InteractableRoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void OnEnter(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
