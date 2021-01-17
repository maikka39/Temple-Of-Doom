using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class EntityLocation : BaseObservable<IEntityLocation>, IEntityLocation
    {
        /// <summary>
        /// Creates a new instance from the specified location
        /// </summary>
        /// <param name="room">Specifies the starting room</param>
        /// <param name="x">Specifies the starting x coordinate</param>
        /// <param name="y">Specifies the starting y coordinate</param>
        public EntityLocation(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        ///<inheritdoc/>
        public IRoom Room { get; private set; }

        ///<inheritdoc/>
        public int X { get; private set; }

        ///<inheritdoc/>
        public int Y { get; private set; }

        ///<inheritdoc/>
        public Direction? LastDirection { get; private set; }

        /// <summary>
        /// Checks if the entity can move to the specified location and if so, does it
        /// Updates the subscribers afterwards
        /// </summary>
        /// <param name="room">The new room</param>
        /// <param name="x">The new x coordinate</param>
        /// <param name="y">The new y coordinate</param>
        /// <param name="direction">The direction in which the entity went</param>
        public void Update(IRoom room, int x, int y, Direction? direction = null)
        {
            if (!room.IsWithinBoundaries(x, y))
                return;

            Room = room;
            X = x;
            Y = y;
            LastDirection = direction;

            NotifyObservers(this);
        }
    }
}
