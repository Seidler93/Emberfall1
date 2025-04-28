using UnityEngine;

public class WeaponDamageCollider : MonoBehaviour
{
    private ActionCombat playerCombat;

    void Start()
    {
        playerCombat = GetComponentInParent<ActionCombat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter" + other.name);

        // if (!playerCombat.dealDamage) return;

        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            if (playerCombat.TryRegisterHit(enemy))
            {
                enemy.TakeDamage(playerCombat.lightAttackDamage);
            }
        }
    }
}
