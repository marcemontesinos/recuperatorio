using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f; // Vida m�xima del enemigo
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        Debug.Log($"El enemigo recibi� {amount} de da�o. Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject); // Destruye el enemigo
    }
}