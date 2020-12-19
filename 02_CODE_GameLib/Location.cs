namespace CODE_GameLib
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
    
    public static class DirectionExtensions
    {
        public static bool IsVertical(this Direction direction) => direction == Direction.North || direction == Direction.South;
        public static bool IsHorizontal(this Direction direction) => !IsVertical(direction);
    }
}
