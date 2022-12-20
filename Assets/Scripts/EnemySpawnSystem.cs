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
    private Random _random;
    private float3 _minPos = new float3(-20, -10, 0);
    private float3 _maxPos = new float3(20, 10, 0);


    protected override void OnStartRunning()
    {
        _enemyPrefab = GetSingleton<EnemyPrefab>().Value;
        _random.InitState(11);

        PlayerPrefs.SetInt("enemyCount", 0);
    }

    protected override void OnUpdate()
    {
        var count = PlayerPrefs.GetInt("enemyCount");
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (count == 0)
            {
                for (int n = 0; n < 10; n++)
                {
                    var newEnemy = EntityManager.Instantiate(_enemyPrefab);

                    float3 randPos;
                    int i = _random.NextInt(0, 2);

                    if (i == 0)
                    {
                        float randX = _random.NextFloat(-20, 20);
                        float randY = Mathf.Sign(_random.NextFloat(-1, 1)) * 10;
                        randPos = new float3(randX, randY, 0);
                    }
                    else
                    {
                        float randX = Mathf.Sign(_random.NextFloat(-1, 1)) * 20;
                        float randY = _random.NextFloat(-10, 10);
                        randPos = new float3(randX, randY, 0);
                    }

                    Translation newPos = new() { Value = randPos };
                    EntityManager.SetComponentData(newEnemy, newPos);

                    count++;
                }
                PlayerPrefs.SetInt("enemyCount", count);
                
            }
            Debug.Log(count);
        }
    }
}
