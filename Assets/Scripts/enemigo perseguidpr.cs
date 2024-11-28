using UnityEngine;

public class EnemyWithDamage : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float detectionRange = 10f; // Rango de detección
    public float moveSpeed = 3f; // Velocidad de movimiento
    public float attackRange = 2f; // Rango de ataque
    public int damageAmount = 10; // Cantidad de daño por ataque
    public float attackCooldown = 1.5f; // Tiempo entre ataques

    private bool playerDetected = false;
    private float attackTimer = 0f;

    void Update()
    {
        // Calcular la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Detectar al jugador si está en rango
        playerDetected = distanceToPlayer <= detectionRange;

        // Si detecta al jugador, moverse hacia él
        if (playerDetected && distanceToPlayer > attackRange)
        {
            ChasePlayer();
        }

        // Atacar si el jugador está dentro del rango de ataque
        if (playerDetected && distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }

        // Actualizar el temporizador de ataque
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void ChasePlayer()
    {
        // Moverse hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Rotar hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackPlayer()
    {
        if (attackTimer <= 0f)
        {
            Debug.Log("Enemy attacks the player!");

            // Obtener el script de salud del jugador
            JugadorVida jugadorVida = player.GetComponent<JugadorVida>(); // Asegúrate de que el jugador tenga este componente

            if (jugadorVida != null)
            {
                jugadorVida.RecibirDanio(damageAmount); // Aplica el daño
            }

            attackTimer = attackCooldown; // Restablecer el temporizador de ataque
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el rango de detección en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Visualizar el rango de ataque
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}