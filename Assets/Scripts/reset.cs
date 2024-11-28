using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar las escenas

public class ResetGame : MonoBehaviour
{
    void Update()
    {
        // Detecta si se presiona la tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    // Método para recargar la escena actual
    void ResetScene()
    {
        // Obtiene el nombre de la escena actual y la recarga
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}