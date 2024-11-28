using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float followSpeed = 3f;     // Velocidad de movimiento del enemigo
    public float explosionRadius = 5f; // Radio en el que explota
    public float explosionDamage = 50f; // Daño que inflige la explosión
    public float detectionRadius = 10f; // Radio de detección del jugador
    public float fieldOfView = 60f;    // Ángulo de visión del enemigo
    public GameObject explosionEffect; // Prefab del efecto de explosión

    private bool isExploding = false;  // Bandera para evitar múltiples explosiones

    void Update()
    {
        if (isExploding) return; // Evita que el enemigo actúe mientras explota

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Comprobar si el jugador está dentro del radio de detección y en el campo de visión
        if (distanceToPlayer <= detectionRadius && IsPlayerInSight())
        {
            FollowPlayer();

            // Explota si el jugador está dentro del radio de explosión
            if (distanceToPlayer <= explosionRadius)
            {
                Explode();
            }
        }
    }

    private void FollowPlayer()
    {
        // Mover hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;

        // Mirar hacia el jugador
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    private bool IsPlayerInSight()
    {
        // Calcular dirección hacia el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Ángulo entre la dirección hacia el jugador y la dirección frontal del enemigo
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Comprobar si el jugador está dentro del ángulo de visión
        return angle <= fieldOfView / 2f;
    }

    private void Explode()
    {
        isExploding = true;

        // Crear efecto de explosión
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar objetos en el radio de explosión
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                // Infligir daño al jugador
                JugadorVida jugador = hitCollider.GetComponent<JugadorVida>();
                if (jugador != null)
                {
                    jugador.RecibirDanio(explosionDamage);
                }
            }
        }

        // Destruir al enemigo
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el radio de explosión en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // Dibuja el radio de detección en la escena
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}