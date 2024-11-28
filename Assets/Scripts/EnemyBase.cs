using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int damage = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " muri�.");
        Destroy(gameObject); // Elimina el enemigo
    }
}