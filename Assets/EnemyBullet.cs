using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public float danio = 10f; // Daño que causa la bala

    private void OnCollisionEnter(Collision collision)
    {
        // Si la bala colisiona con el jugador (asegúrate de que el jugador tiene el tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtén el script JugadorVida del jugador
            JugadorVida jugadorVida = collision.gameObject.GetComponent<JugadorVida>();

            // Si el jugador tiene el script JugadorVida
            if (jugadorVida != null)
            {
                // Aplica el daño al jugador
                jugadorVida.RecibirDanio(danio);
            }

            // Destruye la bala después de la colisión
            Destroy(gameObject);
        }
    }
}