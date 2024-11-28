using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Salud máxima del enemigo
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce la salud

        // Verifica si el enemigo murió
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo ha muerto");
        Destroy(gameObject); // Destruye al enemigo
    }
}