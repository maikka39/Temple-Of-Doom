using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public sealed class Door : IDoor
    {
        public Door()
        {
        }

        public bool Opened { get; set; }

        public bool CanEnter(IEntity entity)
        {
            return CanBypass(entity) || Opened;
        }

        private static bool CanBypass(IEntity entity)
        {
            if (entity is IPlayer player)
                return player.IsCheatEnabled(Cheat.IgnoreDoors);

            return false;
        }
    }
}
