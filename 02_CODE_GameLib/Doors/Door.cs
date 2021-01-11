using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public abstract class Door : IDoor
    {
        private bool _opened;

        public virtual bool Opened
        {
            get => _opened;
            set => _opened = value;
        }

        protected Door()
        {
        }

        protected Door(bool opened)
        {
            _opened = opened;
        }

        public virtual bool CanEnter(IEntity entity)
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
