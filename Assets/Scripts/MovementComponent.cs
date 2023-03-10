using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MovementComponent : IComponentData
{
    public MovementComponent(float speed)
    {
        this.speed = speed;
    }

    public float speed;
}
