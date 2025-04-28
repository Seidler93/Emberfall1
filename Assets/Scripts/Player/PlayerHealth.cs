using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public PlayerStatusBar playerStatusBar;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage: " + amount);
        UpdatePlayerHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Player died.");
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdatePlayerHealthBar();
        Debug.Log("Healed! Current HP: " + currentHealth);
    }

    public void Die()
    {
        // Reloads the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdatePlayerHealthBar() 
    {
        playerStatusBar.UpdateHealthBar(currentHealth, maxHealth);
    }

}
