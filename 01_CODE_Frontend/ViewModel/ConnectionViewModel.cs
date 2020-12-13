using System;
using CODE_GameLib;
using CODE_GameLib.Doors;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Items.Doors;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel
    {
        private readonly IConnection _connection;
        private IRoom _room;

        public int X { get; }
        public int Y { get; }
        public ConsoleText View => new DoorViewModel(_connection.Door, _connection.Direction).View;
        
        public ConnectionViewModel(IConnection connection, IRoom room)
        {
            _connection = connection;
            _room = room;

            switch (connection.Direction)
            {
                case Direction.Top:
                case Direction.Bottom:
                    X = (_room.Width + 1) / 2 - 1;
                    Y = connection.Direction == Direction.Bottom ? 0 : _room.Height - 1;
                    break;
                case Direction.Right:
                case Direction.Left:
                    X = connection.Direction == Direction.Left ? 0 : _room.Width - 1;
                    Y = (_room.Height + 1) / 2 - 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
    }
}
