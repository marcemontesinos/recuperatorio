using UnityEngine;

public class EnemyBombThrower : MonoBehaviour
{
    public GameObject bombPrefab; // Prefab de la bomba
    public Transform bombSpawnPoint; // Punto donde se generarán las bombas
    public float throwForce = 10f; // Fuerza del lanzamiento
    public float fireRate = 2f; // Frecuencia de lanzamiento

    private float nextFireTime;

    void Update()
    {
        // Verifica si es hora de lanzar una bomba
        if (Time.time > nextFireTime)
        {
            ThrowBomb();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ThrowBomb()
    {
        if (bombPrefab == null)
        {
            Debug.LogWarning("Bomb prefab is not assigned or has been destroyed!");
            return;
        }
        Debug.Log("Throwing bomb!");
        // Instancia la bomba en el punto de generación
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);

        // Aplica una fuerza para lanzarla hacia adelante
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(bombSpawnPoint.forward * throwForce, ForceMode.Impulse);
        }
    }
}