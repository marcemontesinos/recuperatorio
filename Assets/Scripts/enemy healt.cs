using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float salud = 100f;  // Salud del enemigo

    // Método para recibir daño
    public void RecibirDanio(float cantidad)
    {
        salud -= cantidad;

        // Si la salud llega a cero o menos, el enemigo muere
        if (salud <= 0)
        {
            Destroy(gameObject);  // Destruye al enemigo cuando se muere
        }
    }
}