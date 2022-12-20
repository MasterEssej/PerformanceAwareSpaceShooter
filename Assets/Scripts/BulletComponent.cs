using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct BulletComponent : IComponentData
{
    public BulletComponent(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
        direction = new float3(0, 0, 0);
    }

    public int damage;
    public float speed;
    public float3 direction;
}
