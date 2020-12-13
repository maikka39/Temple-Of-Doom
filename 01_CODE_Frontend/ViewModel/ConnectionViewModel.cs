using System;
using CODE_GameLib;
using CODE_GameLib.Interfaces;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel
    {
        private readonly IConnection _connection;

        public int X { get; }
        public int Y { get; }
        public ConsoleText View => new DoorViewModel(_connection.Door, _connection.Direction).View;
        
        public ConnectionViewModel(IConnection connection, IRoom room)
        {
            _connection = connection;

            switch (connection.Direction)
            {
                case Direction.Top:
                case Direction.Bottom:
                    X = (room.Width + 1) / 2 - 1;
                    Y = connection.Direction == Direction.Bottom ? 0 : room.Height - 1;
                    break;
                case Direction.Right:
                case Direction.Left:
                    X = connection.Direction == Direction.Left ? 0 : room.Width - 1;
                    Y = (room.Height + 1) / 2 - 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
    }
}
