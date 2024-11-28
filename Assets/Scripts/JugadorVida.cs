using UnityEngine;
using UnityEngine.UI;  // Para trabajar con la UI
using UnityEngine.SceneManagement;  // Para manejar escenas

public class JugadorVida : MonoBehaviour
{
    public float vidaMaxima = 100f;  // Vida m�xima del jugador
    private float vidaActual;        // Vida actual del jugador
    public Slider barraDeVida;       // Referencia a la barra de vida en la UI

    void Start()
    {
        // Inicializamos la vida actual con la vida m�xima al inicio
        vidaActual = vidaMaxima;

        // Aseg�rate de que la barra de vida est� completamente llena al inicio
        barraDeVida.maxValue = vidaMaxima;
        barraDeVida.value = vidaActual;
    }

    // M�todo para recibir da�o
    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;

        // Aseg�rate de que la vida no baje de cero
        vidaActual = Mathf.Max(vidaActual, 0);

        // Actualizar la barra de vida
        barraDeVida.value = vidaActual;

        // Si la vida llega a 0, reiniciamos la escena
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // M�todo para cuando el jugador muere
    void Morir()
    {
        // Aqu� puedes agregar la l�gica para cuando el jugador muere, como desactivar el personaje, mostrar un mensaje de "Game Over", etc.
        Debug.Log("El jugador ha muerto");

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Curar(float cantidad)
    {
        vidaActual += cantidad;

        // Aseg�rate de que la vida no exceda el m�ximo
        vidaActual = Mathf.Min(vidaActual, vidaMaxima);

        // Actualiza la barra de vida
        barraDeVida.value = vidaActual;

        Debug.Log($"Vida actual: {vidaActual}");
    }

    public void AumentarVidaMaxima(float cantidad)
    {
        vidaMaxima += cantidad;           // Incrementa la vida m�xima
        vidaActual += cantidad;           // Incrementa la vida actual tambi�n
        vidaActual = Mathf.Min(vidaActual, vidaMaxima); // Asegura que la vida actual no exceda la m�xima

        // Actualiza la barra de vida
        barraDeVida.maxValue = vidaMaxima; // Ajusta el valor m�ximo de la barra
        barraDeVida.value = vidaActual;   // Actualiza el valor actual en la barra

        Debug.Log($"Nueva vida m�xima: {vidaMaxima}, vida actual: {vidaActual}");
    }


}
