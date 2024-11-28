using UnityEngine;

public class balastorretas : MonoBehaviour
{
    public float damage = 20f;  // Daño del proyectil
    public float speed = 10f;   // Velocidad del proyectil

    private void Start()
    {
        // Agregar una velocidad al proyectil
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;  // Mover el proyectil hacia adelante
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el script de vida del jugador
            JugadorVida jugadorVida = collision.gameObject.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                jugadorVida.RecibirDanio(damage);  // Infligir daño al jugador
            }

            // Destruir el proyectil después de la colisión
            Destroy(gameObject);
        }
    }
}