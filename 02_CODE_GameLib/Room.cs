using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Tiles;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        private readonly Dictionary<IEnemy, List<IDisposable>> _enemySubscriptions = new Dictionary<IEnemy, List<IDisposable>>();

        public Room(int width, int height, List<IItem> items, List<ITile> tiles, List<IEnemy> enemies,
            IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Tiles = tiles;
            Enemies = enemies;
            Connections = connections;

            foreach (var enemy in Enemies)
            {
                enemy.Location.Update(this, enemy.Location.X, enemy.Location.Y);
                
                var list = new List<IDisposable>
                {
                    enemy.Subscribe(new EntityDiedObserver(this)),
                    enemy.Location.Subscribe(new EntityLocationObserver(enemy))
                };

                _enemySubscriptions.Add(enemy, list);
                
            }
        }

        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public List<ITile> Tiles { get; }
        public List<IEnemy> Enemies { get; }
        public IEnumerable<IConnection> Connections { get; }

        public bool IsWithinBoundaries(int x, int y)
        {
            return x >= 1 && x <= Width - 2 && y >= 1 && y <= Height - 2;
        }

        public int CenterX => (Width + 1) / 2 - 1;
        public int CenterY => (Height + 1) / 2 - 1;

        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
        }

        public bool Update()
        {
            if (!Enemies.Any()) return false;

            Enemies.ForEach(enemy => enemy.Update());

            return true;
        }

        public void Check(IEntity entity)
        {
            TryEnterTile(entity);

            if (entity is IPlayer player)
            {
                TryEnterItem(player);
                TryEnterEnemy(player);
            }
        }

        public IEnumerable<IEnemy> GetEnemiesWithinReach(IEntityLocation location)
        {
            return Enemies.Where(enemy =>
                enemy.Location.X == location.X + 1 && enemy.Location.Y == location.Y ||
                enemy.Location.X == location.X - 1 && enemy.Location.Y == location.Y ||
                enemy.Location.X == location.X && enemy.Location.Y == location.Y + 1 ||
                enemy.Location.X == location.X && enemy.Location.Y == location.Y - 1
            );
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            _enemySubscriptions[enemy].ForEach(a => a.Dispose());
            _enemySubscriptions.Remove(enemy);
            Enemies.Remove(enemy);
        }

        private IItem GetItem(int x, int y)
        {
            return Items.FirstOrDefault(item => item.X == x && item.Y == y);
        }

        private ITile GetTile(int x, int y)
        {
            return Tiles.FirstOrDefault(tile => tile.X == x && tile.Y == y);
        }

        private IEnemy GetEnemy(int x, int y)
        {
            return Enemies.FirstOrDefault(enemy => enemy.Location.X == x && enemy.Location.Y == y);
        }

        private void TryEnterItem(IPlayer player)
        {
            var roomItem = GetItem(player.Location.X, player.Location.Y);
            roomItem?.OnEnter(player);
        }

        private void TryEnterTile(IEntity entity)
        {
            var roomTile = GetTile(entity.Location.X, entity.Location.Y);
            roomTile?.OnEnter(entity, entity.Location.LastDirection);
        }

        private void TryEnterEnemy(IPlayer player)
        {
            var roomEnemy = GetEnemy(player.Location.X, player.Location.Y);
            roomEnemy?.OnEnter(player);
        }
    }
}
