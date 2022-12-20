using System.Collections;
using System.Collections.Generic;

using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Jobs;
using Debug = UnityEngine.Debug;

public partial class CollisionSystem : SystemBase
{
    private StepPhysicsWorld stepPhysicsWorld;
    private EntityCommandBufferSystem commandBufferSystem;







    protected override void OnCreate()
    {


        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }



    protected override void OnUpdate()
    {
        var job = new DestroyOnTriggerSystemJob
        {
            allProjectiles = GetComponentDataFromEntity<BulletComponent>(true),
            allPlayers = GetComponentDataFromEntity<PlayerComponent>(true),
            allEnemies = GetComponentDataFromEntity<EnemyComponent>(true),
            allHealth = GetComponentDataFromEntity<HealthComponent>(true),
            entityCommandBuffer = commandBufferSystem.CreateCommandBuffer()
        };
        Dependency = job.Schedule(stepPhysicsWorld.Simulation, Dependency);
        commandBufferSystem.AddJobHandleForProducer(Dependency);



    }

    [BurstCompile]
    struct DestroyOnTriggerSystemJob : ITriggerEventsJob
    {
        [ReadOnly] public ComponentDataFromEntity<BulletComponent> allProjectiles;
        [ReadOnly] public ComponentDataFromEntity<PlayerComponent> allPlayers;
        [ReadOnly] public ComponentDataFromEntity<EnemyComponent> allEnemies;
        [ReadOnly] public ComponentDataFromEntity<HealthComponent> allHealth;
        public EntityCommandBuffer entityCommandBuffer;

        public void Execute(TriggerEvent triggerEvent)
        {
            //Debug.Log("Collision triggered");


            Entity entityA = triggerEvent.EntityA;
            Entity entityB = triggerEvent.EntityB;
            if (allProjectiles.HasComponent(entityA) && allProjectiles.HasComponent(entityB))
                return;
            if (allProjectiles.HasComponent(entityA) && allPlayers.HasComponent(entityB))
                return;
            if (allPlayers.HasComponent(entityA) && allProjectiles.HasComponent(entityB))
                return;
            /*
            if (allProjectiles.HasComponent(entityA) && allEnemies.HasComponent(entityB))
            {
                Debug.Log("projectile destroyed");
                entityCommandBuffer.DestroyEntity(entityA);
                entityCommandBuffer.DestroyEntity(entityB);
            }*/

            
            if (allEnemies.HasComponent(entityA) && allProjectiles.HasComponent(entityB))
            {
                Debug.Log("projectile destroyed2");
                
                var maxHealth = allHealth[entityA].maxHealth;
                var newHealth = allHealth[entityA].currentHealth - allProjectiles[entityB].damage;
                HealthComponent healthComponent = new HealthComponent { maxHealth = maxHealth, currentHealth = newHealth };
                entityCommandBuffer.SetComponent<HealthComponent>(entityA, healthComponent);

                entityCommandBuffer.DestroyEntity(entityB);
            }

            if (allPlayers.HasComponent(entityA) && allEnemies.HasComponent(entityB))
            {
                Debug.Log("player enemy collision");

                var maxHealth = allHealth[entityA].maxHealth;
                var newHealth = allHealth[entityA].currentHealth - allEnemies[entityB].damage;
                HealthComponent healthComponent = new HealthComponent { maxHealth = maxHealth, currentHealth = newHealth };
                entityCommandBuffer.SetComponent<HealthComponent>(entityA, healthComponent);

                entityCommandBuffer.DestroyEntity(entityB);
            }
            else if (allEnemies.HasComponent(entityB) && allPlayers.HasComponent(entityA))
            {
                Debug.Log("player enemy collision");

                var maxHealth = allHealth[entityA].maxHealth;
                var newHealth = allHealth[entityA].currentHealth - allEnemies[entityB].damage;
                HealthComponent healthComponent = new HealthComponent { maxHealth = maxHealth, currentHealth = newHealth };
                entityCommandBuffer.SetComponent<HealthComponent>(entityA, healthComponent);

                entityCommandBuffer.DestroyEntity(entityB);
            }

        }
    }






}