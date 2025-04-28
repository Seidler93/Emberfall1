using UnityEngine;

public class AutoAttacker : MonoBehaviour
{
    public TargetingSystem targetingSystem;
    public float attackRange = 3f;
    public float attackInterval = 1.5f;
    public float damage = 20f;

    private float lastAttackTime = 0f;

    void Update()
    {
        var target = targetingSystem.currentTarget;
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= attackRange && Time.time - lastAttackTime >= attackInterval)
            {
                if (target.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Attacked: " + enemy.name);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
