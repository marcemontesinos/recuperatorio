using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform shootPoint;  // El punto desde donde se dispara (normalmente en la mano o cañón de un arma)

    void Update()
    {
        // Detecta cuando el jugador presiona el botón de disparo (puedes cambiar la tecla)
        if (Input.GetButtonDown("Fire1"))  // Fire1 es el botón por defecto para disparar (clic izquierdo del ratón)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instancia un proyectil en la posición y rotación del punto de disparo
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}