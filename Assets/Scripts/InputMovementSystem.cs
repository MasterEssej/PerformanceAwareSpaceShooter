using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


public partial class InputMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        int xMovement = 0;
        int yMovement = 0;
        float rotationSpeed = 3f;
        float rotationDirection = 0f;
        

        
        if(Input.GetKey("a")) { xMovement = -1; }
        if(Input.GetKey("d")) { xMovement = 1; }
        if(Input.GetKey("w")) { yMovement = 1; }
        if(Input.GetKey("s")) { yMovement = -1; }

        if(Input.GetKey(KeyCode.LeftArrow)) { rotationDirection = -1; }
        if(Input.GetKey(KeyCode.RightArrow)) { rotationDirection = 1; }
        

        float3 direction = new float3(xMovement, yMovement, 0);

        Entities.WithAll<PlayerComponent>().ForEach((ref Translation translation, ref Rotation rotation, ref MovementComponent movementComponent) =>
        {
            Quaternion currentQuaternion = rotation.Value;
            float rot = currentQuaternion.eulerAngles.z;
            rot -= rotationDirection * rotationSpeed;

            Quaternion newQuaternion = Quaternion.identity;
            newQuaternion.eulerAngles = new Vector3(0, 0, rot);

            rotation.Value = newQuaternion;

            translation.Value += direction * deltaTime * movementComponent.speed;

        }).Schedule();


    }
}
