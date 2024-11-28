using UnityEngine;

public class bullets : MonoBehaviour
{
    public int damage = 10; // Daño que causa la bala
    public float speed = 20f; // Velocidad de la bala
    public float lifetime = 5f; // Tiempo antes de que la bala se destruya

    void Start()
    {
        // Destruye la bala después de un tiempo para evitar que siga volando indefinidamente
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Intenta obtener el componente de salud del objeto impactado
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            // Aplica daño al enemigo
            enemyHealth.TakeDamage(damage);
        }

        // Destruye la bala después de colisionar
        Destroy(gameObject);
    }
}