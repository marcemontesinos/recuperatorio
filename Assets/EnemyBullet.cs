using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public float danio = 10f; // Da�o que causa la bala

    private void OnCollisionEnter(Collision collision)
    {
        // Si la bala colisiona con el jugador (aseg�rate de que el jugador tiene el tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obt�n el script JugadorVida del jugador
            JugadorVida jugadorVida = collision.gameObject.GetComponent<JugadorVida>();

            // Si el jugador tiene el script JugadorVida
            if (jugadorVida != null)
            {
                // Aplica el da�o al jugador
                jugadorVida.RecibirDanio(danio);
            }

            // Destruye la bala despu�s de la colisi�n
            Destroy(gameObject);
        }
    }
}