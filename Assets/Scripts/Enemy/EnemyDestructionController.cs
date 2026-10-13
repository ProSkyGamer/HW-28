#region

using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

#endregion

namespace Enemy
{
    public class EnemyDestructionController : Controller
    {
        private readonly List<EnemyRegistration> _registeredEnemies = new();

        public int Spawned => _registeredEnemies.Count;

        public void Register(Enemy enemy, params EnemyDeathCondition[] deathConditions)
        {
            List<EnemyDeathCondition> enemyDeathConditions = new(deathConditions);
            EnemyRegistration enemyRegistration = new(enemy, enemyDeathConditions);

            _registeredEnemies.Add(enemyRegistration);
        }

        public void Register(Enemy enemy, Action<EnemyDeathConditionsBuilder> conditionsAction)
        {
            EnemyDeathConditionsBuilder deathConditionsBuilder = new();
            conditionsAction?.Invoke(deathConditionsBuilder);

            EnemyDeathCondition[] deathConditions = deathConditionsBuilder.Build();
            Register(enemy, deathConditions);
        }

        protected override void UpdateInternal(float deltaTime)
        {
            for (int i = _registeredEnemies.Count - 1; i >= 0; i--)
            {
                EnemyRegistration enemyRegistration = _registeredEnemies[i];
                enemyRegistration.UpdateLifetime(deltaTime);

                if (enemyRegistration.Enemy == null)
                {
                    enemyRegistration.RemoveRegistration();
                    _registeredEnemies.RemoveAt(i);

                    continue;
                }

                bool shouldDestroy = false;

                foreach (EnemyDeathCondition condition in enemyRegistration.DeathConditions)
                {
                    if (condition(enemyRegistration, this))
                    {
                        shouldDestroy = true;

                        break;
                    }
                }

                if (shouldDestroy)
                {
                    enemyRegistration.RemoveRegistration();
                    _registeredEnemies.RemoveAt(i);
                }
            }

            Debug.Log($"[EnemyDestructionService] Зарегистрировано врагов: {Spawned}");
        }
    }
}