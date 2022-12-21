using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[UpdateBefore(typeof(ShootingSystem))]
public partial class PlayerSpawnSystem : SystemBase
{
    public Entity player;

    protected override void OnStartRunning()
    {
        PlayerPrefs.SetInt("IsPlayerDead", 0);
        player = EntityManager.Instantiate(GetSingleton<PlayerPrefab>().Value);
        Translation spawnPos = new Translation { Value = new float3(0, 0, 0) };
        EntityManager.SetComponentData<Translation>(player, spawnPos);
    }

    protected override void OnUpdate()
    {
        
    }
}
