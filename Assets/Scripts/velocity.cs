using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float healingAmount = 20f; // Cantidad de vida que restaura el �tem

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que toca el �tem es el jugador
        if (other.CompareTag("Player"))
        {
            // Obt�n la referencia al componente JugadorVida
            JugadorVida jugadorVida = other.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                // Aumenta la vida del jugador
                jugadorVida.Curar(healingAmount);

                // Destruye el �tem despu�s de que se recoja
                Destroy(gameObject);
            }
        }
    }
}