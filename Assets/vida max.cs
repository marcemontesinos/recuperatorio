using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthItem : MonoBehaviour
{
    public float extraHealth = 20f; // Cantidad de vida m�xima adicional que proporciona el �tem

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprueba si el objeto que colisiona es el jugador
        {
            JugadorVida jugadorVida = other.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                jugadorVida.AumentarVidaMaxima(extraHealth); // Aumenta la vida m�xima del jugador
                Destroy(gameObject); // Destruye el �tem despu�s de ser recogido
            }
        }
    }
}