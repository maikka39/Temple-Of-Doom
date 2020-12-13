using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public class ToggleDoor : IToggleDoor
    {
        public bool Opened { get; set; }

        public bool PassThru(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
