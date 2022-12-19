using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateBefore(typeof(ShootingSystem))]
public partial class PlayerSpawnSystem : SystemBase
{
    public Entity player;

    protected override void OnStartRunning()
    {
        player = EntityManager.Instantiate(GetSingleton<PlayerPrefab>().Value);
    }

    protected override void OnUpdate()
    {
        
    }
}
