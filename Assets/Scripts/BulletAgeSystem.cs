using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class BulletAgeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.WithStructuralChanges().ForEach((Entity entity, ref ShootingComponent bullet) =>
        {
            bullet.age += deltaTime;
            if(bullet.age > bullet.maxAge)
            {
                EntityManager.DestroyEntity(entity);
            }
        }).Run();
    }
}
