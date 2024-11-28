using UnityEngine;
using UnityEngine.UI;  // Para trabajar con la UI
using UnityEngine.SceneManagement;  // Para manejar escenas

public class JugadorVida : MonoBehaviour
{
    public float vidaMaxima = 100f;  // Vida máxima del jugador
    private float vidaActual;        // Vida actual del jugador
    public Slider barraDeVida;       // Referencia a la barra de vida en la UI

    void Start()
    {
        // Inicializamos la vida actual con la vida máxima al inicio
        vidaActual = vidaMaxima;

        // Asegúrate de que la barra de vida esté completamente llena al inicio
        barraDeVida.maxValue = vidaMaxima;
        barraDeVida.value = vidaActual;
    }

    // Método para recibir daño
    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;

        // Asegúrate de que la vida no baje de cero
        vidaActual = Mathf.Max(vidaActual, 0);

        // Actualizar la barra de vida
        barraDeVida.value = vidaActual;

        // Si la vida llega a 0, reiniciamos la escena
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Método para cuando el jugador muere
    void Morir()
    {
        // Aquí puedes agregar la lógica para cuando el jugador muere, como desactivar el personaje, mostrar un mensaje de "Game Over", etc.
        Debug.Log("El jugador ha muerto");

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Curar(float cantidad)
    {
        vidaActual += cantidad;

        // Asegúrate de que la vida no exceda el máximo
        vidaActual = Mathf.Min(vidaActual, vidaMaxima);

        // Actualiza la barra de vida
        barraDeVida.value = vidaActual;

        Debug.Log($"Vida actual: {vidaActual}");
    }

    public void AumentarVidaMaxima(float cantidad)
    {
        vidaMaxima += cantidad;           // Incrementa la vida máxima
        vidaActual += cantidad;           // Incrementa la vida actual también
        vidaActual = Mathf.Min(vidaActual, vidaMaxima); // Asegura que la vida actual no exceda la máxima

        // Actualiza la barra de vida
        barraDeVida.maxValue = vidaMaxima; // Ajusta el valor máximo de la barra
        barraDeVida.value = vidaActual;   // Actualiza el valor actual en la barra

        Debug.Log($"Nueva vida máxima: {vidaMaxima}, vida actual: {vidaActual}");
    }


}
