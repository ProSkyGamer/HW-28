#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Enemy
{
    public class EnemyRegistration
    {
        public EnemyRegistration(Enemy enemy, List<EnemyDeathCondition> deathConditions)
        {
            _deathConditions = deathConditions;
            _enemy = enemy;
            Lifetime = 0f;
        }

        private readonly Enemy _enemy;
        public IReadonlyEnemy Enemy => _enemy;

        private readonly List<EnemyDeathCondition> _deathConditions;
        public IReadOnlyList<EnemyDeathCondition> DeathConditions => _deathConditions;

        public float Lifetime { get; private set; }

        public void UpdateLifetime(float deltaTime)
        {
            Lifetime += deltaTime;
        }

        public void RemoveRegistration()
        {
            if (_enemy != null)
                Object.Destroy(_enemy.gameObject);
        }
    }
}