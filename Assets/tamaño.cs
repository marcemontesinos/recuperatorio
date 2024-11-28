using UnityEngine;
using System.Collections;

public class SizeBoostItem : MonoBehaviour
{
    public Vector3 sizeIncrease = new Vector3(1f, 1f, 1f); // Tamaño a aumentar
    public float duration = 5f; // Duración del efecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprueba que sea el jugador
        {
            StartCoroutine(ChangeSizeTemporarily(other.transform));
            Destroy(gameObject); // Elimina el ítem del juego
        }
    }

    private IEnumerator ChangeSizeTemporarily(Transform player)
    {
        Vector3 originalSize = player.localScale; // Guarda el tamaño original
        player.localScale += sizeIncrease;       // Aumenta el tamaño
        yield return new WaitForSeconds(duration); // Espera la duración
        player.localScale = originalSize;        // Restaura el tamaño original
    }
}