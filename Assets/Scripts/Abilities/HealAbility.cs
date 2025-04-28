using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal")]
public class HealAbility : Ability
{
    public float healAmount = 30f;

    public override void Use(GameObject user, TargetingSystem targetingSystem)
    {
        if (user.TryGetComponent<PlayerHealth>(out var health))
        {
            Debug.Log("Casted: Heal");

            health.Heal(healAmount);
        }
    }
}
