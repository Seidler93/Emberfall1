using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Quick Strike")]
public class QuickStrikeAbility : Ability
{
    public float damage = 30f;
    public float range = 3f;

    public override void Use(GameObject user, TargetingSystem targetingSystem)
    {
                Debug.Log("Attempting: QuickStrike");

        if (targetingSystem.currentTarget != null &&
            Vector3.Distance(user.transform.position, targetingSystem.currentTarget.position) < range)
        {
            if (targetingSystem.currentTarget.TryGetComponent<Enemy>(out var enemy))
            { 
                Debug.Log("Casted: QuickStrike");

                enemy.TakeDamage(damage);
            }
        }
    }

}
