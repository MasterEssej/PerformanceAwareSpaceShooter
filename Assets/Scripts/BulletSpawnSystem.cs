using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class BulletSpawnSystem : SystemBase
{
    /*
    private Entity bulletPrefab;
    private Entity _playerEntity;

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        bulletPrefab = GetSingleton<BulletPrefab>().Value;
        _playerEntity = World.GetExistingSystem<PlayerSpawnSystem>().player;
    }*/

    protected override void OnUpdate()
    {
        /*
        float3 playerPos = EntityManager.GetComponentData<Translation>(_playerEntity).Value;
        Quaternion playerRot = EntityManager.GetComponentData<Rotation>(_playerEntity).Value;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = EntityManager.Instantiate(bulletPrefab);

            float3 newDirection = math.normalize(playerRot * Vector3.up);

            float3 spawnPos = playerPos + newDirection;
            Translation newTranslation = new() { Value = spawnPos };
            EntityManager.SetComponentData<Translation>(bullet, newTranslation);

            BulletComponent bulletData = new() { direction = newDirection, speed = 20 };
            EntityManager.SetComponentData<BulletComponent>(bullet, bulletData);
        }*/

    }
}
