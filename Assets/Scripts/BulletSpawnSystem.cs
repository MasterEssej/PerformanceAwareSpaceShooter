using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class BulletSpawnSystem : SystemBase
{
    private Entity _bulletPrefab;
    private Entity _player;
    public Entity bullet;

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        _bulletPrefab = GetSingleton<BulletPrefab>().Value;
        _player = World.GetExistingSystem<PlayerSpawnSystem>().player;
    }

    protected override void OnUpdate()
    {
        
    }

}
