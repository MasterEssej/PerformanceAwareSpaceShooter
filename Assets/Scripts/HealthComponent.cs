using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct HealthComponent : IComponentData
{
    public HealthComponent(int maxHealth, int currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }

    public int maxHealth;
    public int currentHealth;
}
