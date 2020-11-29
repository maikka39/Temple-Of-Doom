namespace CODE_GameLib.Interfaces.Items.Doors
{
    public interface IDoor : IItem
    {
        public bool Opened { get; set; }
    }
}