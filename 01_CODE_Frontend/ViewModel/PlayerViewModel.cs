﻿using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_Frontend.ViewModel
{
    public class PlayerViewModel
    {
        private readonly IPlayer _player;
        
        public int X => _player.Location.X;
        public int Y => _player.Location.Y;
        public static ConsoleText View => new ConsoleText("P");

        public PlayerViewModel(IPlayer player)
        {
            _player = player;
        }
    }
}
