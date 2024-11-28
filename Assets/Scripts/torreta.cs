using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform shootPoint;  // El punto desde donde se dispara el proyectil
    public float shootRate = 5f;  // Velocidad de disparo (dispara cada segundo)
    public float rotationSpeed = 5f;  // Velocidad de rotación para mirar al jugador
    private float nextShootTime = 5f;  // Tiempo para el siguiente disparo

    void Update()
    {
        // Seguir al jugador
        FollowPlayer();

        // Solo disparar si ha pasado el tiempo suficiente (control de shootRate)
        Shoot();
    }

    void FollowPlayer()
    {
        // Rotar la torreta hacia el jugador
        Vector3 direction = player.position - transform.position;  // Dirección hacia el jugador
        Quaternion targetRotation = Quaternion.LookRotation(direction);  // Rotación hacia el jugador
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);  // Rotar suavemente
    }

    void Shoot()
    {
        // Verificar si ha pasado el tiempo suficiente para disparar
        if (Time.time >= nextShootTime)
        {
            Vector3 direction = player.position - transform.position;
            // Disparar un proyectil
            Instantiate(bulletPrefab, shootPoint.position,Quaternion.LookRotation(direction));
            
           // Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);


            // Establecer el tiempo para el siguiente disparo
            nextShootTime = Time.time + 5f / shootRate;  // Solo disparar después del intervalo de tiempo
        }
    }
}