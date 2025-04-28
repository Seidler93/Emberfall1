using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldown;
    public Sprite icon;

    protected float lastCastTime;

    public float LastUsed => lastCastTime;
    public bool IsOffCooldown => Time.time - lastCastTime >= cooldown;

    public void TryUse(GameObject user, TargetingSystem targeting)
    {
        // if (IsOffCooldown)
        // {
            Use(user, targeting);
            lastCastTime = Time.time;
        // }
    }

    public abstract void Use(GameObject user, TargetingSystem targeting);
}
