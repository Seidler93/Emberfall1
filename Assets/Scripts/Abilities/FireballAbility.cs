using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fireball")]
public class FireballAbility : Ability
{
    public GameObject projectilePrefab;
    public float damage = 25f;
    public float speed = 10f;

    public override void Use(GameObject user, TargetingSystem targetingSystem)
    {
        Debug.Log("Casted: Fireball");
        Transform spawnPoint = user.transform;
        GameObject proj = Instantiate(projectilePrefab, spawnPoint.position + spawnPoint.forward * 1f, spawnPoint.rotation);
        proj.GetComponent<Projectile>().Initialize(damage, speed);
    }
}
