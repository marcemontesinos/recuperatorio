using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float healingAmount = 20f; // Cantidad de vida que restaura el ítem

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que toca el ítem es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtén la referencia al componente JugadorVida
            JugadorVida jugadorVida = other.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                // Aumenta la vida del jugador
                jugadorVida.Curar(healingAmount);

                // Destruye el ítem después de que se recoja
                Destroy(gameObject);
            }
        }
    }
}