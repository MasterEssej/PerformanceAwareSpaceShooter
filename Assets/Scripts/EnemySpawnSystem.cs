using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Random = Unity.Mathematics.Random;

public partial class EnemySpawnSystem : SystemBase
{
    private Entity _enemyPrefab;
    private Entity _enemySpawner;
    private Random _random;
    private float3 _minPos = new float3(-20, -10, 0);
    private float3 _maxPos = new float3(20, 10, 0);

    protected override void OnStartRunning()
    {
        _enemyPrefab = GetSingleton<EnemyPrefab>().Value;
        EntityManager.AddComponent<MovementComponent>(_enemyPrefab);
        EntityManager.AddComponent<EnemyComponent>(_enemyPrefab);
        _random.InitState(10);
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var newEnemy = EntityManager.Instantiate(_enemyPrefab);

            float3 randPos = _random.NextFloat3(_minPos, _maxPos);
            Translation newPos = new Translation { Value = randPos };
            EntityManager.SetComponentData(newEnemy, newPos);
             
            MovementComponent newSpeed = new MovementComponent {speed = 2f };
            EntityManager.SetComponentData(newEnemy, newSpeed);
            
        }
    }
}
