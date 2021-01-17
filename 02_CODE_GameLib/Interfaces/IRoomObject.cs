namespace CODE_GameLib.Interfaces
{
    /// <summary>
    /// A general object within a room
    /// </summary>
    public interface IRoomObject
    {
        /// <summary>
        /// Specifies the x coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Specifies the y coordinate
        /// </summary>
        public int Y { get; }
    }
}
