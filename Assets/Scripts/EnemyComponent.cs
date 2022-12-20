using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct EnemyComponent : IComponentData
{
    public EnemyComponent(int damage)
    {
        this.damage = damage;
    }

    public int damage;
}
