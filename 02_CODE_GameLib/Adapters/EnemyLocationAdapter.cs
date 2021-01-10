using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Observers;
using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Adapters
{
    public class EnemyLocationAdapter : BaseObservable<IEntityLocation>, IEntityLocation
    {
        private readonly Enemy _adaptee;

        public IRoom Room { get; private set; }

        public int X
        {
            get => _adaptee.CurrentXLocation;
            private set => _adaptee.CurrentXLocation = value;
        }

        public int Y
        {
            get => _adaptee.CurrentYLocation;
            private set => _adaptee.CurrentYLocation = value;
        }
        
        public Direction? LastDirection { get; private set; }
        
        public EnemyLocationAdapter(Enemy enemy)
        {
            _adaptee = enemy;
        }
        
        public bool Update(IRoom room, int x, int y, Direction? direction = null)
        {
            if (!room.IsWithinBoundaries(x, y))
                return false;
            
            Room = room;
            X = x;
            Y = y;
            LastDirection = direction;
            
            NotifyObservers(this);
            return true;
        }

        public void Update()
        {
            NotifyObservers(this);
        }
    }
}
