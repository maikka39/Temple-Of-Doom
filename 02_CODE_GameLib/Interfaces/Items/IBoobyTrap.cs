namespace CODE_GameLib.Interfaces.Items
{
    public interface IBoobyTrap : IItem
    {
        public int Damage { get; }
        public bool Disappearing { get;  }
    }
}