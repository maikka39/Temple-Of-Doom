using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    /// <summary>
    /// Implements a base class for room objects
    /// </summary>
    public abstract class RoomObject : IRoomObject
    {
        /// <summary>
        /// Creates a new instance at the specified location
        /// </summary>
        /// <param name="x">The x coordinate of the object</param>
        /// <param name="y">The y coordinate of the object</param>
        protected RoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        ///<inheritdoc/>
        public virtual int X { get; }
        
        ///<inheritdoc/>
        public virtual int Y { get; }
    }
}
