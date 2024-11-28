using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint;     // Punto desde donde se disparan las balas
    public float bulletSpeed = 20f; // Velocidad de las balas
    public float fireRate = 0.5f;   // Tiempo entre disparos
    public float fireRateMultiplier = 1f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // "Fire1" es el clic izquierdo por defecto
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Controla el tiempo entre disparos
            nextFireTime = Time.time + (fireRate / fireRateMultiplier);
        }

    }

    void Shoot()
    {
        // Crear la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed; // Aplica velocidad a la bala
        }
    }
    public void IncreaseFireRate(float multiplier, float duration)
    {
        // Aumenta la velocidad de disparo
        fireRateMultiplier *= multiplier;

        // Si el efecto es temporal, restaura el valor original después de "duration" segundos
        StartCoroutine(RestoreFireRate(duration));
    }

    private IEnumerator RestoreFireRate(float duration)
    {
        yield return new WaitForSeconds(duration);
        fireRateMultiplier = 1f; // Restaurar a su valor por defecto
    }

}