using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateBefore(typeof(ShootingSystem))]
public partial class PlayerSpawnSystem : SystemBase
{
    private Entity _player;
    public Entity player;


    protected override void OnStartRunning()
    {
        /*
        _player = GetSingleton<PlayerPrefab>().Value;
        EntityManager.AddComponent<MovementComponent>(_player);
        EntityManager.AddComponent<PlayerComponent>(_player);
        player = EntityManager.Instantiate(_player);
        */

        player = EntityManager.Instantiate(GetSingleton<PlayerPrefab>().Value);
        EntityManager.AddComponent<MovementComponent>(player);
        EntityManager.AddComponent<PlayerComponent>(player);

        MovementComponent newSpeed = new MovementComponent { speed = 5f };
        EntityManager.SetComponentData(player, newSpeed);
    }

    protected override void OnUpdate()
    {
        
    }
}
