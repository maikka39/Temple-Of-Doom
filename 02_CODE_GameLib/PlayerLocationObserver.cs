using System;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib
{
    public class PlayerLocationObserver : IObserver<IPlayerLocation>
    {
        private readonly IGame _game;

        public PlayerLocationObserver(IGame game, IPlayerLocation playerLocation)
        {
            _game = game;
            playerLocation.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IPlayerLocation playerLocation)
        {
            var roomItem = playerLocation.Room.Items.FirstOrDefault(item =>
                item.X == playerLocation.X && item.Y == playerLocation.Y);
            switch (roomItem)
            {
                case IWearable wearable:
                    _game.Player.AddToInventory(wearable);
                    break;
                case IBoobyTrap boobyTrap:
                    _game.Player.RecieveDamage(boobyTrap.Damage);
                    break;
                case IPressurePlate _:
                    foreach (var connection in playerLocation.Room.Connections.Where(conn => conn.Door is IToggleDoor))
                        connection.Door.Opened = !connection.Door.Opened;
                    break;
            }

            if (roomItem is IWearable || roomItem is IDisapearingTrap)
                playerLocation.Room.Items.Remove(roomItem);

            _game.Update();
        }
    }
}