using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform jugador;  // Referencia al jugador
    public float velocidad = 3f; // Velocidad de movimiento del enemigo
    public float rangoDeAtaque = 1f; // Rango de ataque cuando el enemigo toca al jugador
    public float danioPorSegundo = 10f; // Daño que hace el enemigo al jugador por segundo

    private void Update()
    {
        // Mover al enemigo hacia el jugador
        if (jugador != null)
        {
            float step = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, step);
        }

        // Comprobar si el enemigo está dentro del rango de ataque
        if (Vector3.Distance(transform.position, jugador.position) <= rangoDeAtaque)
        {
            // Llamamos al método de recibir daño del jugador
            JugadorVida jugadorVida = jugador.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                jugadorVida.RecibirDanio(danioPorSegundo * Time.deltaTime); // Daño por segundo
            }
        }
    }
}