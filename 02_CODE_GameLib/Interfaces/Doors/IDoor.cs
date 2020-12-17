namespace CODE_GameLib.Interfaces.Doors
{
    public interface IDoor
    {
        public bool Opened { get; set; }

        public bool CanEnter(IPlayer player);
    }
}
