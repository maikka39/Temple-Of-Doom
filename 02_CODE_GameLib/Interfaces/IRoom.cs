using System.Collections.Generic;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Interfaces
{
    public interface IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public List<ITile> Tiles { get; }
        public List<IEnemy> Enemies { get; }
        public IEnumerable<IConnection> Connections { get; }
        public int CenterX { get; }
        public int CenterY { get; }
        public bool IsWithinBoundaries(int x, int y);
        public void RemoveItem(IItem item);
        public bool Update();
        public void Check(IPlayer player);
        public IEnumerable<IEnemy> GetEnemiesWithinReach(IEntityLocation location);
        public void RemoveEnemy(IEnemy enemy);
    }
}
