# PerformanceAwareSpaceShooter

I used the Entity Component System to manage objects as entities. 

I used data components to separately store the data for different parts of the game such as movement or health in general components that I could attach to entities.
I then made systems for handling the different data.

For example. the components "MovementComponent" and "HealthComponent", would be manipulated in the systems "MovementSystem" and "HealthSystem".

In the systems I used jobs like "Entities.ForEach" to manipulate the component data for all entities with the component attached. The same component can be attached on different entities. This means that we can use the same system to update things like movement and health for all different types of enemies as long as they have the relevant component attached. It can also be specified that the entity needs a specific component attached like "EnemyComponent" so that for example health data will not be updated for the player in the same way as the enemies. 
