using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EntityManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype playerArchetype = entityManager.CreateArchetype(typeof(Transform), typeof(HealthComponent), typeof(PlayerComponent));
        EntityArchetype enemyArchetype = entityManager.CreateArchetype(typeof(Transform), typeof(HealthComponent));

        Entity player = entityManager.CreateEntity(playerArchetype);
        Entity enemy = entityManager.CreateEntity(enemyArchetype);

        entityManager.SetComponentData(enemy, new HealthComponent { currentHealth = 10 });

        entityManager.SetComponentData(player, new HealthComponent { currentHealth = 10 });






    }




}
