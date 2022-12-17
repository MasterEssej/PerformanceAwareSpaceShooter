using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class MovementSystem : SystemBase
{
    private Entity _playerEntity;
    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        _playerEntity = World.GetExistingSystem<PlayerSpawnSystem>().player;
    }
    protected override void OnUpdate()
    {
        float3 playerPos = EntityManager.GetComponentData<Translation>(_playerEntity).Value;
        float deltaTime = Time.DeltaTime;
        Entities.WithAll<EnemyComponent>().ForEach((ref MovementComponent movementComponent, ref Translation translation) =>
        {
            var direction = math.normalize(playerPos - translation.Value)*deltaTime*movementComponent.speed;

            translation.Value += direction;
        })
            .Schedule();
    }
}
