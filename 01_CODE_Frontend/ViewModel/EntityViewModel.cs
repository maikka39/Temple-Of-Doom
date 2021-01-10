using System;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_Frontend.ViewModel
{
    public class EntityViewModel
    {
        private readonly IEntity _entity;
        
        public int X => _entity.Location.X;
        public int Y => _entity.Location.Y;
        public ConsoleText View => GetEntityConsoleText(_entity);

        public EntityViewModel(IEntity entity)
        {
            _entity = entity;
        }
        
        private static ConsoleText GetEntityConsoleText(IEntity entity)
        {
            return entity switch
            {
                IPlayer _ => new ConsoleText("P", ConsoleColor.White),
                IEnemy _ => new ConsoleText("E", ConsoleColor.Red),
                _ => new ConsoleText("?")
            };
        }
    }
}
