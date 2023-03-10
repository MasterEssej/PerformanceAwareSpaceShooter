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
    private int enemyAmount;
    private int enemyAmountMultiplier;
    public Renderer renderer;

    protected override void OnStartRunning()
    {
        _enemyPrefab = GetSingleton<EnemyPrefab>().Value;
        _random.InitState(11);
        enemyAmount = 100;
        enemyAmountMultiplier = 1;
        PlayerPrefs.SetInt("enemyCount", 0);
    }

    protected override void OnUpdate()
    {
        var count = PlayerPrefs.GetInt("enemyCount");
        //if (Input.GetKeyDown(KeyCode.P)) { }
        if (count == 0)
        {
            enemyAmount *= enemyAmountMultiplier;
            for (int n = 0; n < enemyAmount; n++)
            {
                Entity newEnemy = EntityManager.Instantiate(_enemyPrefab);
                //EntityManager.RemoveComponent<CompanionGameObjectUpdateTransformSystem>(newEnemy);

                float3 randPos;
                int i = _random.NextInt(0, 2);

                if (i == 0)
                {
                    float randX = _random.NextFloat(-60, 60);
                    float randY = Mathf.Sign(_random.NextFloat(-1, 1)) * 30;
                    randPos = new float3(randX, randY, 0);
                }
                else
                {
                    float randX = Mathf.Sign(_random.NextFloat(-1, 1)) * 60;
                    float randY = _random.NextFloat(-30, 30);
                    randPos = new float3(randX, randY, 0);
                }

                Translation newPos = new() { Value = randPos };
                EntityManager.SetComponentData(newEnemy, newPos);

                count++;
            }
            PlayerPrefs.SetInt("enemyCount", count);
            enemyAmountMultiplier++;

        }
        Debug.Log(count);

    }
}
