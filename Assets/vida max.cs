using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthItem : MonoBehaviour
{
    public float extraHealth = 20f; // Cantidad de vida máxima adicional que proporciona el ítem

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprueba si el objeto que colisiona es el jugador
        {
            JugadorVida jugadorVida = other.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                jugadorVida.AumentarVidaMaxima(extraHealth); // Aumenta la vida máxima del jugador
                Destroy(gameObject); // Destruye el ítem después de ser recogido
            }
        }
    }
}