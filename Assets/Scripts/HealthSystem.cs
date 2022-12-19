using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class HealthSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithStructuralChanges().ForEach((Entity entity, ref HealthComponent healthComponent) =>
        {
            if(healthComponent.currentHealth <= 0)
            {
                EntityManager.DestroyEntity(entity);
            }
        }).Run();
    }
}
