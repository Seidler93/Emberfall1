using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public TargetingSystem targetingSystem;

    public Ability[] abilities;
    public AbilitySlotUI[] hotbarSlots;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilities[0]?.TryUse(gameObject, targetingSystem);
            hotbarSlots[0]?.Flash();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilities[1]?.TryUse(gameObject, targetingSystem);
            hotbarSlots[1]?.Flash();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilities[2]?.TryUse(gameObject, targetingSystem);
            hotbarSlots[2]?.Flash();
        }
    }

}
