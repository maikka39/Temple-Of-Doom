using System.Reflection;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Observers;
using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Adapters
{
    /// <summary>
    /// Adapts the provided Enemy DLC to an IEntityLocation
    /// </summary>
    public class EnemyLocationAdapter : BaseObservable<IEntityLocation>, IEntityLocation
    {
        private readonly Enemy _adaptee;

        /// <summary>
        /// Creates a new instance from an enemy
        /// </summary>
        /// <param name="enemy"></param>
        public EnemyLocationAdapter(Enemy enemy)
        {
            _adaptee = enemy;
        }

        ///<inheritdoc/>
        public IRoom Room { get; private set; }

        ///<inheritdoc/>
        public int X
        {
            get => _adaptee.CurrentXLocation;
            private set => _adaptee.CurrentXLocation = value;
        }

        ///<inheritdoc/>
        public int Y
        {
            get => _adaptee.CurrentYLocation;
            private set => _adaptee.CurrentYLocation = value;
        }

        ///<inheritdoc/>
        public Direction? LastDirection
        {
            get
            {
                // Absolutely horrible method but as CurrentDirectionX is protected, this
                // is the only way we can get access to it. We need this access to get the
                // current direction for, for example, an ice tile. This is because an
                // ice tile slides the enemy forwards and we thus need to know where it
                // came from.
                var currentDirectionX = (int) (_adaptee.GetType().GetProperty("CurrentDirectionX", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(_adaptee) ?? 0);
                var currentDirectionY = (int) (_adaptee.GetType().GetProperty("CurrentDirectionY", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(_adaptee) ?? 0);
                
                if (currentDirectionX > 0)
                    return Direction.East;
                if (currentDirectionX < 0)
                    return Direction.West;
                if (currentDirectionY > 0)
                    return Direction.North;
                if (currentDirectionY < 0)
                    return Direction.South;

                return null;
            }
        }

        ///<inheritdoc/>
        public void Update(IRoom room, int x, int y, Direction? direction = null)
        {
            if (!room.IsWithinBoundaries(x, y))
                return;

            Room = room;
            X = x;
            Y = y;

            NotifyObservers(this);
        }

        /// <summary>
        /// Updates the subscribers
        /// </summary>
        public void Update()
        {
            NotifyObservers(this);
        }
    }
}
