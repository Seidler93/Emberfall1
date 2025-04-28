using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealthBar healthBar;
    public Transform healthBarAnchor; // Empty object above head
    public GameObject selectionCircle;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        if (selectionCircle != null)
            selectionCircle.SetActive(false);
    }

    public void SetSelected(bool isSelected)
    {
        if (selectionCircle != null)
            selectionCircle.SetActive(isSelected);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

