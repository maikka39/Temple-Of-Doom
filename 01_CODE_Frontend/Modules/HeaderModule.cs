using System;
using System.Collections.Generic;
using System.Linq;
using CODE_Frontend.ViewModel;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_Frontend.Modules
{
    public class HeaderModule
    {
        /// <summary>
        /// Contains the time at which the game started.
        /// Used to calculate the playtime
        /// </summary>
        private readonly DateTime _startTime;
        
        /// <summary>
        /// The player playing the game
        /// </summary>
        private IPlayer _player;

        public HeaderModule()
        {
            _startTime = DateTime.Now;
        }

        /// <summary>
        /// Sets the title message
        /// </summary>
        private static string Title => "Welcome to Temple of Doom!";

        /// <summary>
        /// Calculates the playtime
        /// </summary>
        private string PlayTime => $"Playtime: {DateTime.Now.Subtract(_startTime):hh\\:mm\\:ss}";
        
        /// <summary>
        /// Gets the amount of sankara stones
        /// </summary>
        private string SankaraStones => $"Sankara Stones: {_player.Inventory.Count(item => item is ISankaraStone)}";
        
        /// <summary>
        /// Gets the amount of lives left
        /// </summary>
        private string Lives => $"Lives: {_player.Lives}";

        /// <summary>
        /// Renders this module
        /// </summary>
        /// <param name="game">The newest state of the game</param>
        /// <returns>A collection of ConsoleText with the messages to print</returns>
        public IEnumerable<ConsoleText> Render(IGame game)
        {
            _player = game.Player;

            yield return new ConsoleText(Title);
            yield return new ConsoleText(GenericModule.ConsoleClearLineTillEnd() + Environment.NewLine);

            yield return new ConsoleText(Lives);
            yield return new ConsoleText(" - ");
            yield return new ConsoleText(SankaraStones, ConsoleColor.DarkYellow);
            yield return new ConsoleText(" - ");
            yield return new ConsoleText(PlayTime);
            yield return new ConsoleText(GenericModule.ConsoleClearLineTillEnd() + Environment.NewLine);

            // Get all inventory items
            foreach (var item in GetInventory())
            {
                yield return item;
                yield return new ConsoleText(" ");
            }

            // Get all cheats
            foreach (var item in GetCheats())
                yield return item;

            yield return new ConsoleText(GenericModule.ConsoleClearLineTillEnd() + Environment.NewLine);
            yield return new ConsoleText(GenericModule.HorizontalLine(Console.WindowWidth), ConsoleColor.Gray);
        }

        /// <summary>
        /// Gets the view models of the inventory items
        /// </summary>
        /// <returns>A collection of ConsoleText containing the items</returns>
        private IEnumerable<ConsoleText> GetInventory()
        {
            yield return new ConsoleText("Inventory:");

            foreach (var item in _player.Inventory.Where(item => !(item is ISankaraStone)))
                yield return new RoomObjectViewModel(item).View;
        }

        /// <summary>
        /// Gets the view models of the cheats
        /// </summary>
        /// <returns>A collection of ConsoleText containing the cheats</returns>
        private IEnumerable<ConsoleText> GetCheats()
        {
            if (!_player.EnabledCheats.Any())
                yield break;

            yield return new ConsoleText(GenericModule.ConsoleClearLineTillEnd() + Environment.NewLine);
            yield return new ConsoleText("Cheats:", ConsoleColor.Red);

            foreach (var cheat in _player.EnabledCheats.OrderBy(cheat => cheat.ToString()))
                yield return new ConsoleText($" {cheat.ToString()}");
        }
    }
}
