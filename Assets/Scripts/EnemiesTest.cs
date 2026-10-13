#region

using System;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

namespace DefaultNamespace
{
    public class EnemiesTest : MonoBehaviour
    {
        [SerializeField] private Enemy.Enemy _enemyPrefab;

        [SerializeField] private Transform _spawnAreaTopRightCorner;
        [SerializeField] private Transform _spawnAreaBottomLeftCorner;

        private const KeyCode SpawnWithIsDeadConditionKeyCode = KeyCode.Alpha1;
        private const KeyCode SpawnWithDeadAfterTimeConditionKeyCode = KeyCode.Alpha2;
        private const KeyCode SpawnWithDeadOvercrowdConditionKeyCode = KeyCode.Alpha3;

        private EnemyDestructionController _enemyDestructionController;

        private void Awake()
        {
            _enemyDestructionController = new EnemyDestructionController();
            _enemyDestructionController.TurnOn();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            _enemyDestructionController.Update(deltaTime);

            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(SpawnWithIsDeadConditionKeyCode))
                SpawnEnemyWith(builder => builder.WhenDead());

            if (Input.GetKeyDown(SpawnWithDeadAfterTimeConditionKeyCode))
                SpawnEnemyWith(builder => builder.AfterTime(15f));

            if (Input.GetKeyDown(SpawnWithDeadOvercrowdConditionKeyCode))
                SpawnEnemyWith(builder => builder.WhenSpawnedOver(5));
        }

        private void SpawnEnemyWith(Action<EnemyDeathConditionsBuilder> deathConditions)
        {
            Vector3 enemySpawnPosition = GetRandomPositionBetweenPoints(_spawnAreaBottomLeftCorner.position, _spawnAreaTopRightCorner.position);

            Enemy.Enemy enemy = Instantiate(_enemyPrefab, enemySpawnPosition, Quaternion.identity);
            _enemyDestructionController.Register(enemy, deathConditions);
        }

        private Vector3 GetRandomPositionBetweenPoints(Vector3 bottomLeftPoint, Vector3 topRightPoint)
        {
            float xPosition = Random.Range(bottomLeftPoint.x, topRightPoint.x);
            float yRange = Random.Range(bottomLeftPoint.y, topRightPoint.y);
            float zRange = Random.Range(bottomLeftPoint.z, topRightPoint.z);

            Vector3 randomPosition = new Vector3(xPosition, yRange, zRange);

            return randomPosition;
        }
    }
}