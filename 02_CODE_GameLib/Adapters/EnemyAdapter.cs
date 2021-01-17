using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;
using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Adapters
{
    /// <summary>
    /// Adapts the provided Enemy DLC to an IEnemy
    /// </summary>
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

        ///<inheritdoc/>
        public override IEntityLocation Location => _enemyLocationAdapter;

        ///<inheritdoc/>
        public override int Lives => _adaptee.NumberOfLives;

        ///<inheritdoc/>
        public override void ReceiveDamage(int damage)
        {
            _adaptee.GetHurt(damage);
        }

        ///<inheritdoc/>
        public void Update()
        {
            _adaptee.Move();
        }

        ///<inheritdoc/>
        public void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(1);
        }

        /// <summary>
        /// Observes the Enemy and updates the adapters
        /// </summary>
        private class EnemyObserver : BaseObserver<Enemy>
        {
            private readonly EnemyAdapter _enemyAdapter;

            public EnemyObserver(EnemyAdapter enemyAdapter)
            {
                _enemyAdapter = enemyAdapter;
            }
            
            public override void OnNext(Enemy enemy)
            {
                _enemyAdapter.NotifyObservers(_enemyAdapter);
                _enemyAdapter._enemyLocationAdapter.Update();
            }
        }
    }
}
