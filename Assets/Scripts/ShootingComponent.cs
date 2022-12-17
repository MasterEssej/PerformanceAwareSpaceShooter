using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct ShootingComponent : IComponentData
{
    public int damage;
    public int speed;
    public float3 direction;

    public float maxAge;
    public float age;
}
