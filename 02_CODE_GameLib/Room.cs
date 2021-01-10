using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public List<ITile> Tiles { get; }
        public List<IEnemy> Enemies { get; }
        public IEnumerable<IConnection> Connections { get; }

        public Room(int width, int height, List<IItem> items, List<ITile> tiles, List<IEnemy> enemies, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Tiles = tiles;
            Enemies = enemies;
            Connections = connections;
        }

        public bool IsWithinBoundaries(int x, int y) => x >= 1 && x <= Width - 2 && y >= 1 && y <= Height - 2;

        public int CenterX => (Width + 1) / 2 - 1;
        public int CenterY => (Height + 1) / 2 - 1;

        public void RemoveItem(IItem item) => Items.Remove(item);
        private IItem GetItem(int x, int y) => Items.FirstOrDefault(item => item.X == x && item.Y == y);
        private ITile GetTile(int x, int y) => Tiles.FirstOrDefault(tile => tile.X == x && tile.Y == y);
        private IEnemy GetEnemy(int x, int y) => Enemies.FirstOrDefault(enemy => enemy.Location.X == x && enemy.Location.Y == y);
        
        public bool Update()
        {
            if (!Enemies.Any()) return false;
            
            Enemies.ForEach(enemy => enemy.Update());

            return true;
        }

        public void Check(IPlayer player)
        {
            TryEnterTile(player);
            TryEnterItem(player);
            TryEnterEnemy(player);
        }
        
        private void TryEnterItem(IPlayer player)
        {
            var roomItem = GetItem(player.Location.X, player.Location.Y);
            roomItem?.OnEnter(player);
        }

        private void TryEnterTile(IPlayer player)
        {
            var roomTile = GetTile(player.Location.X, player.Location.Y);
            roomTile?.OnEnter(player, player.Location.LastDirection);
        }
        
        private void TryEnterEnemy(IPlayer player)
        {
            var roomEnemy = GetEnemy(player.Location.X, player.Location.Y);
            roomEnemy?.OnEnter(player);
        }
    }
}
