using UnityEngine;

public class p : MonoBehaviour
{
    public float fireRateBoost = 0.5f;  // Factor por el cual se reduce el tiempo entre disparos
    public float boostDuration = 5f;    // Duraci�n del boost en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el script del jugador y aumentar la velocidad de disparo
            controldearma gunControl = other.GetComponent<controldearma>();
            if (gunControl != null)
            {
                gunControl.StartCoroutine(gunControl.FireRateBoost(fireRateBoost, boostDuration));
            }

            // Destruir el item despu�s de ser recogido
            Destroy(gameObject);
        }
    }
}