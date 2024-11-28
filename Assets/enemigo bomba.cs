using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float followSpeed = 3f;     // Velocidad de movimiento del enemigo
    public float explosionRadius = 5f; // Radio en el que explota
    public float explosionDamage = 50f; // Da�o que inflige la explosi�n
    public float detectionRadius = 10f; // Radio de detecci�n del jugador
    public float fieldOfView = 60f;    // �ngulo de visi�n del enemigo
    public GameObject explosionEffect; // Prefab del efecto de explosi�n

    private bool isExploding = false;  // Bandera para evitar m�ltiples explosiones

    void Update()
    {
        if (isExploding) return; // Evita que el enemigo act�e mientras explota

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Comprobar si el jugador est� dentro del radio de detecci�n y en el campo de visi�n
        if (distanceToPlayer <= detectionRadius && IsPlayerInSight())
        {
            FollowPlayer();

            // Explota si el jugador est� dentro del radio de explosi�n
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
        // Calcular direcci�n hacia el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // �ngulo entre la direcci�n hacia el jugador y la direcci�n frontal del enemigo
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Comprobar si el jugador est� dentro del �ngulo de visi�n
        return angle <= fieldOfView / 2f;
    }

    private void Explode()
    {
        isExploding = true;

        // Crear efecto de explosi�n
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar objetos en el radio de explosi�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                // Infligir da�o al jugador
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
        // Dibuja el radio de explosi�n en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // Dibuja el radio de detecci�n en la escena
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}