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
    ///<inheritdoc/>
    public class Room : IRoom
    {
        /// <summary>
        /// Holds all subscriptions for enemies in the room.
        /// Is used to unsubscribe from them if they are killed
        /// </summary>
        private readonly Dictionary<IEnemy, List<IDisposable>> _enemySubscriptions = new Dictionary<IEnemy, List<IDisposable>>();

        /// <summary>
        /// Creates a room from the specified parameters
        /// </summary>
        /// <param name="width">The width of the room</param>
        /// <param name="height">The height of the room</param>
        /// <param name="items">Tho items in the room</param>
        /// <param name="tiles">The tiles in the room</param>
        /// <param name="enemies">The enemies in the room</param>
        /// <param name="connections">The connections in the room</param>
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
                // Tell the enemy in what room it is
                enemy.Location.Update(this, new Location(enemy.Location.X, enemy.Location.Y));
                
                // Create observers which remove the item from the room if it is killed
                var list = new List<IDisposable>
                {
                    enemy.Subscribe(new EntityDiedObserver(this)),
                    enemy.Location.Subscribe(new UpdateRoomEntityLocationObserver(enemy))
                };

                // Add the subscriptions to the subscriptions dictionary
                _enemySubscriptions.Add(enemy, list);
                
            }
        }

        ///<inheritdoc/>
        public int Width { get; }
        
        ///<inheritdoc/>
        public int Height { get; }
        
        ///<inheritdoc/>
        public List<IItem> Items { get; }
        
        ///<inheritdoc/>
        public List<ITile> Tiles { get; }
        
        ///<inheritdoc/>
        public List<IEnemy> Enemies { get; }
        
        ///<inheritdoc/>
        public IEnumerable<IConnection> Connections { get; }
        
        ///<inheritdoc/>
        public bool IsWithinBoundaries(ILocation location)
        {
            return location.X >= 1 && location.X <= Width - 2 && location.Y >= 1 && location.Y <= Height - 2;
        }

        ///<inheritdoc/>
        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
        }

        ///<inheritdoc/>
        public bool Update()
        {
            if (!Enemies.Any()) return false;

            Enemies.ForEach(enemy => enemy.Update());

            return true;
        }

        ///<inheritdoc/>
        public void Check(IEntity entity)
        {
            if (TryEnterTile(entity))
                return;

            if (entity is IPlayer player)
            {
                TryEnterItem(player);
                CheckEnemies(player);
            }
        }

        public void CheckEnemies(IPlayer player)
        {
            TryEnterEnemy(player);
        }

        ///<inheritdoc/>
        public IEnumerable<IEnemy> GetEnemiesWithinReach(IEntityLocation location)
        {
            return Enemies.Where(enemy =>
                enemy.Location.X == location.X + 1 && enemy.Location.Y == location.Y ||
                enemy.Location.X == location.X - 1 && enemy.Location.Y == location.Y ||
                enemy.Location.X == location.X && enemy.Location.Y == location.Y + 1 ||
                enemy.Location.X == location.X && enemy.Location.Y == location.Y - 1
            );
        }

        ///<inheritdoc/>
        public void RemoveEnemy(IEnemy enemy)
        {
            _enemySubscriptions[enemy].ForEach(a => a.Dispose());
            _enemySubscriptions.Remove(enemy);
            Enemies.Remove(enemy);
        }

        /// <summary>
        /// Gets the item the the specified location
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>The item found at the location</returns>
        private IItem GetItem(int x, int y)
        {
            return Items.FirstOrDefault(item => item.X == x && item.Y == y);
        }

        /// <summary>
        /// Gets the tile at the the specified location
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>The tile found at the location</returns>
        private ITile GetTile(int x, int y)
        {
            return Tiles.FirstOrDefault(tile => tile.X == x && tile.Y == y);
        }

        /// <summary>
        /// Gets the enemy the the specified location
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>The enemy found at the location</returns>
        private IEnemy GetEnemy(int x, int y)
        {
            return Enemies.FirstOrDefault(enemy => enemy.Location.X == x && enemy.Location.Y == y);
        }

        /// <summary>
        /// Tries to call OnEnter of an item of the location of the player
        /// </summary>
        /// <param name="player">The player to check for</param>
        private void TryEnterItem(IPlayer player)
        {
            var roomItem = GetItem(player.Location.X, player.Location.Y);
            roomItem?.OnEnter(player);
        }

        /// <summary>
        /// Tries to call OnEnter of a tile of the location of the entity
        /// </summary>
        /// <param name="entity">The player to check for</param>
        private bool TryEnterTile(IEntity entity)
        {
            var roomTile = GetTile(entity.Location.X, entity.Location.Y);
            return roomTile?.OnEnter(entity) ?? false;
        }

        /// <summary>
        /// Tries to call OnEnter of an enemy of the location of the player
        /// </summary>
        /// <param name="player">The player to check for</param>
        private void TryEnterEnemy(IPlayer player)
        {
            var roomEnemy = GetEnemy(player.Location.X, player.Location.Y);
            roomEnemy?.OnEnter(player);
        }
    }
}
