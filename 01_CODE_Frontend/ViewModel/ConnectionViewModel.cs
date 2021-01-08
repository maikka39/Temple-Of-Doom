using CODE_GameLib.Interfaces;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel
    {
        private readonly IConnection _connection;

        public int X => _connection.X;
        public int Y => _connection.Y;
        public ConsoleText View => new DoorViewModel(_connection.Door, _connection.Direction).View;
        
        public ConnectionViewModel(IConnection connection)
        {
            _connection = connection;
        }
    }
}
