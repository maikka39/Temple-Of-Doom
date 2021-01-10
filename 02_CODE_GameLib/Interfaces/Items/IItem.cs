namespace CODE_GameLib.Interfaces.Items
{
    public interface IItem: IRoomObject
    {
        public void OnEnter(IPlayer player);
    }
}
