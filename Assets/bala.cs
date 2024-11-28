using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;       // Daño que inflige la bala
    public float lifetime = 5f;     // Tiempo antes de que la bala se destruya

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destruye la bala después de cierto tiempo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Detecta colisiones con enemigos
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Aplica daño al enemigo
            }

            Destroy(gameObject); // Destruye la bala después de impactar
        }
    }
}