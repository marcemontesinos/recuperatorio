using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform shootPoint;  // El punto desde donde se dispara (normalmente en la mano o ca��n de un arma)

    void Update()
    {
        // Detecta cuando el jugador presiona el bot�n de disparo (puedes cambiar la tecla)
        if (Input.GetButtonDown("Fire1"))  // Fire1 es el bot�n por defecto para disparar (clic izquierdo del rat�n)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instancia un proyectil en la posici�n y rotaci�n del punto de disparo
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}