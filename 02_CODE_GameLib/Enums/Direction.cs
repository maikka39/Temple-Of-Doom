namespace CODE_GameLib.Enums
{
    /// <summary>
    /// An enum of all directions in which an connection or player can go
    /// </summary>
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Upper = 4,
        Lower = 5
    }

    /// <summary>
    /// Extensions for this enum
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// Checks if the direction is vertical, meaning either north or south
        /// </summary>
        /// <param name="direction">The direction to check for</param>
        /// <returns>A boolean with the result</returns>
        public static bool IsVertical(this Direction direction)
        {
            return direction == Direction.North || direction == Direction.South;
        }

        /// <summary>
        /// Checks if the direction is horizontal, meaning either east or west
        /// </summary>
        /// <param name="direction">The direction to check for</param>
        /// <returns>A boolean with the result</returns>
        public static bool IsHorizontal(this Direction direction)
        {
            return direction == Direction.East || direction == Direction.West;
        }
    }
}
