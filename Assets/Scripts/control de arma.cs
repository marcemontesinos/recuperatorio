using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controldearma : MonoBehaviour
{
    public Transform shootSpawn;

    public bool shooting;

    public GameObject bulletprefab;

    public float fireRate = 0.5f;  // Tiempo entre disparos (en segundos)
    private float normalFireRate;
    // Start is called before the first frame update
    void Start()
    {
        normalFireRate = fireRate;
    }
   
    // Update is called once per frame
    void Update()

    {
     


        Cursor.lockState = CursorLockMode.Locked;

        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (shooting )

        {
            InstantiateBullet();

        }
    }

    public void InstantiateBullet()
    {
        Instantiate(bulletprefab, shootSpawn.position, shootSpawn.rotation);

    }
    public IEnumerator FireRateBoost(float amount, float duration)
    {
        Debug.Log("Activando boost de velocidad de disparo");
        fireRate *= amount;  // Reduce el tiempo entre disparos
        yield return new WaitForSeconds(duration);  // Espera durante el tiempo especificado
        fireRate = normalFireRate;  // Restaura el tiempo de disparo normal
    }
}
