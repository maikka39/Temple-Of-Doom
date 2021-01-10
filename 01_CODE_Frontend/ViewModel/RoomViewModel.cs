﻿using System;
using System.Linq;
using CODE_GameLib.Interfaces;

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
            
            // Set connections
            foreach (var connection in _room.Connections.Select(connection => new ConnectionViewModel(connection)))
                _grid[connection.X, connection.Y] = connection.View;

            
            // Set room objects
            var roomObjects = _room.Items.Union<IRoomObject>(_room.Tiles);
            foreach (var item in roomObjects.Select(roomObjects => new RoomObjectViewModel(roomObjects)))
                _grid[item.X, item.Y] = item.View;

            // Set player
            var playerViewModel = new PlayerViewModel(_player);
            _grid[playerViewModel.X, playerViewModel.Y] = PlayerViewModel.View;

            return _grid;
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
