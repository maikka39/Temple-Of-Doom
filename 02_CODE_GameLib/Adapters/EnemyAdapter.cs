using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;
using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Adapters
{
    public class EnemyAdapter : Entity.Entity, IEnemy
    {
        private readonly Enemy _adaptee;
        private readonly EnemyLocationAdapter _enemyLocationAdapter;

        public EnemyAdapter(Enemy enemy, EnemyLocationAdapter enemyLocationAdapter)
        {
            _adaptee = enemy;
            _enemyLocationAdapter = enemyLocationAdapter;

            _adaptee.Subscribe(new EnemyObserver(this));
        }

        public new IEntityLocation Location => _enemyLocationAdapter;

        public new int Lives => _adaptee.NumberOfLives;
        public new void ReceiveDamage(int damage) => _adaptee.GetHurt(damage);
        public void Update() => _adaptee.Move();
        public void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(1);
        }

        private class EnemyObserver : BaseObserver<Enemy>, IObserver<Enemy>
        {
            private readonly EnemyAdapter _enemyAdapter;

            public EnemyObserver(EnemyAdapter enemyAdapter)
            {
                _enemyAdapter = enemyAdapter;
            }

            public new void OnNext(Enemy value)
            {
                _enemyAdapter.NotifyObservers(_enemyAdapter);
                _enemyAdapter._enemyLocationAdapter.Update();
            }
        }
    }
}
