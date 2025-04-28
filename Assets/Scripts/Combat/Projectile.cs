using UnityEngine;

public class Projectile : MonoBehaviour
{
    float damage;
    float speed;

    public void Initialize(float dmg, float spd)
    {
        damage = dmg;
        speed = spd;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
