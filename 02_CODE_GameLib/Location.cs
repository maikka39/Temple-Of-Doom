using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    /// <summary>
    /// Implements a location
    /// </summary>
    public class Location : ILocation
    {
        /// <summary>
        /// Creates a new instance for the specified location
        /// </summary>
        /// <param name="x">The x coordinate of the object</param>
        /// <param name="y">The y coordinate of the object</param>
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected Location(ILocation location)
        {
            X = location.X;
            Y = location.Y;
        }

        ///<inheritdoc/>
        public virtual int X { get; }
        
        ///<inheritdoc/>
        public virtual int Y { get; }
    }
}
