namespace CODE_GameLib.Interfaces.Entity
{
    public interface IEnemy : IEntity
    {
        public void Update();
        public void OnEnter(IPlayer player);
    }
}
