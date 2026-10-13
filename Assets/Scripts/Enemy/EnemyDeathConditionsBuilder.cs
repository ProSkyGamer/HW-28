#region

using System;
using System.Collections.Generic;

#endregion

namespace Enemy
{
    public delegate bool EnemyDeathCondition(EnemyRegistration enemyRegistration, EnemyDestructionController service);

    public class EnemyDeathConditionsBuilder
    {
        private readonly List<EnemyDeathCondition> _deathConditions = new();

        public EnemyDeathConditionsBuilder WhenDead()
        {
            _deathConditions.Add((enemyRegistration, service) => enemyRegistration.Enemy.IsDead);

            return this;
        }

        public EnemyDeathConditionsBuilder AfterTime(float time)
        {
            _deathConditions.Add((enemyRegistration, service) => enemyRegistration.Lifetime >= time);

            return this;
        }

        public EnemyDeathConditionsBuilder WhenSpawnedOver(int count)
        {
            _deathConditions.Add((enemy, service) => service.Spawned >= count);

            return this;
        }

        public EnemyDeathConditionsBuilder WhenSpawnedLessThan(int count)
        {
            _deathConditions.Add((enemy, service) => service.Spawned < count);

            return this;
        }

        public EnemyDeathConditionsBuilder When(Func<IReadonlyEnemy, EnemyDestructionController, bool> condition)
        {
            _deathConditions.Add((enemyRegistration, service) => condition(enemyRegistration.Enemy, service));

            return this;
        }

        public EnemyDeathCondition[] Build()
        {
            return _deathConditions.ToArray();
        }
    }
}