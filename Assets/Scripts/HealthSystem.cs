using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Entities;

public partial class HealthSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithStructuralChanges().ForEach((Entity entity, ref HealthComponent healthComponent) =>
        {
            if(healthComponent.currentHealth <= 0)
            {
                if(HasComponent<PlayerComponent>(entity))
                {
                    Debug.Log("Lost");
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    EntityManager.DestroyEntity(entity);
                    var enemyCount = PlayerPrefs.GetInt("enemyCount") - 1;
                    PlayerPrefs.SetInt("enemyCount", enemyCount);
                }
                
            }
        }).Run();
    }
}
