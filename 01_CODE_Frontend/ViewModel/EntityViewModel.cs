using System;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_Frontend.ViewModel
{
    public class EntityViewModel : IViewModel
    {
        private readonly IEntity _entity;

        /// <summary>
        /// Creates a new instances from an entity
        /// </summary>
        /// <param name="entity">The entity to create the view model for</param>
        public EntityViewModel(IEntity entity)
        {
            _entity = entity;
        }

        ///<inheritdoc/>
        public int X => _entity.Location.X;
        
        ///<inheritdoc/>
        public int Y => _entity.Location.Y;
        
        ///<inheritdoc/>
        public ConsoleText View => GetEntityConsoleText(_entity);

        /// <summary>
        /// Gets the appropriate ConsoleText for an entity 
        /// </summary>
        /// <param name="entity">The entity to get the console text for</param>
        /// <returns>The console text for an entity</returns>
        private static ConsoleText GetEntityConsoleText(IEntity entity)
        {
            return entity switch
            {
                IPlayer _ => new ConsoleText("P"),
                IEnemy _ => new ConsoleText("E", ConsoleColor.Red),
                _ => new ConsoleText("?")
            };
        }
    }
}
