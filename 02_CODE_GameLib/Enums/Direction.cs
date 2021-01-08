namespace CODE_GameLib.Enums
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Upper = 4,
        Lower = 5
    }
    
    public static class DirectionExtensions
    {
        public static bool IsVertical(this Direction direction) => direction == Direction.North || direction == Direction.South;
        public static bool IsHorizontal(this Direction direction) => direction == Direction.East || direction == Direction.West;
        public static bool IsLadder(this Direction direction) => direction == Direction.Upper || direction == Direction.Lower;
    }
}
