using UnityEngine;

public class WeaponAnimationRelay : MonoBehaviour
{
    private ActionCombat playerCombat;

    private void Start()
    {
        playerCombat = GetComponentInParent<ActionCombat>();
    }

    public void EndAttack()
    {
        playerCombat?.EndAttack();
    }

    public void StartDamageWindow()
    {
        playerCombat?.StartDamageWindow();
    }

    public void EndDamageWindow()
    {
        playerCombat?.EndDamageWindow();
    }
}
