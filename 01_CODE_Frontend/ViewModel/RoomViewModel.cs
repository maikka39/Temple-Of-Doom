using System;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_Frontend.ViewModel
{
    public class RoomViewModel
    {
        private readonly IRoom _room;
        private readonly IPlayer _player;
        private readonly ConsoleText[,] _grid;

        public RoomViewModel(IRoom room, IPlayer player)
        {
            _room = room;
            _player = player;
            _grid = new ConsoleText[room.Width, room.Height];
        }

        public ConsoleText[,] GetGrid()
        {
            InitializeGrid();
            AddConnectionsToGrid();
            AddRoomObjectsToGrid();
            AddEnemiesToGrid();
            AddPlayerToGrid();

            return _grid;
        }

        private void AddPlayerToGrid()
        {
            var playerViewModel = new EntityViewModel(_player);
            _grid[playerViewModel.X, playerViewModel.Y] = playerViewModel.View;
        }

        private void AddEnemiesToGrid()
        {
            foreach (var enemy in _room.Enemies.Select(enemy => new EntityViewModel(enemy)))
                _grid[enemy.X, enemy.Y] = enemy.View;
        }
        
        private void AddRoomObjectsToGrid()
        {
            var roomObjects = _room.Items.Union<IRoomObject>(_room.Tiles);
            foreach (var item in roomObjects.Select(roomObject => new RoomObjectViewModel(roomObject)))
                _grid[item.X, item.Y] = item.View;
        }

        private void AddConnectionsToGrid()
        {
            foreach (var connection in _room.Connections.Select(connection => new ConnectionViewModel(connection)))
                _grid[connection.X, connection.Y] = connection.View;
        }

        private void InitializeGrid()
        {
            var wallConsoleText = new ConsoleText("#", ConsoleColor.Yellow);

            for (var col = 0; col < _grid.GetLength(0); col++)
            {
                _grid[col, 0] = wallConsoleText;
                _grid[col, _grid.GetLength(1) - 1] = wallConsoleText;

                var consoleText = new ConsoleText(" ");

                if (col == 0 || col == _grid.GetLength(0) - 1)
                    consoleText = wallConsoleText;

                for (var row = 1; row < _grid.GetLength(1) - 1; row++)
                    _grid[col, row] = consoleText;
            }
        }

    }
}
