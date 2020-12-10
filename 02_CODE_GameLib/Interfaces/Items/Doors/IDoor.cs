namespace CODE_GameLib.Interfaces.Items.Doors
{
    public interface IDoor
    {
        public bool Opened { get; set; }

        public bool PassThru(IPlayer player);
    }
}