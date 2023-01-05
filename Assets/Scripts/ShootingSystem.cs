using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class ShootingSystem : SystemBase
{
    private Entity bulletPrefab;
    private Entity _playerEntity;

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        bulletPrefab = GetSingleton<BulletPrefab>().Value;
        _playerEntity = World.GetExistingSystem<PlayerSpawnSystem>().player;
    }

    protected override void OnUpdate()
    {
        
        var deltaTime = Time.DeltaTime;
        float3 playerPos = EntityManager.GetComponentData<Translation>(_playerEntity).Value;
        Quaternion playerRot = EntityManager.GetComponentData<Rotation>(_playerEntity).Value;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var bullet = EntityManager.Instantiate(bulletPrefab);
            
            float3 newDirection = math.normalize(playerRot * Vector3.up);

            float3 spawnPos = playerPos + newDirection;
            Translation newTranslation = new() { Value = spawnPos };
            EntityManager.SetComponentData<Translation>(bullet, newTranslation);

            var bulletData = GetComponent<BulletComponent>(bullet);
            BulletComponent newBulletData = new() { direction = newDirection, speed = bulletData.speed, damage = bulletData.damage };
            EntityManager.SetComponentData<BulletComponent>(bullet, newBulletData);
            
        }
        
        Entities.ForEach((ref BulletComponent bulletComponent, ref Translation translation) =>
        {
            translation.Value += bulletComponent.direction * bulletComponent.speed * deltaTime;
        }).Schedule();


        if(Input.GetKeyDown(KeyCode.K))
        {
            Entities.WithAll<EnemyComponent>().ForEach((ref HealthComponent healthComponent) =>
            {
                healthComponent.currentHealth = 0;
            }).Schedule();
        }


    }
}
