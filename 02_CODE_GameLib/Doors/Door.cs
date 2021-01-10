using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public abstract class Door: IDoor
    {
        public bool Opened { get; set; }

        public bool CanEnter(IPlayer player)
        {
            return CanBypass(player) || Opened;
        }

        private static bool CanBypass(IPlayer player)
        {
            return player.IsCheatEnabled(Cheat.IgnoreDoors);
        }
    }
}
