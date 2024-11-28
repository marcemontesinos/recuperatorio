using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manupausa : MonoBehaviour
{
    public GameObject ObejtoMenuPausa;
    public bool Pausa = false;

    // Referencia al script controldearma
    public controldearma scriptDeArma;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pausa == false)
            {
                ObejtoMenuPausa.SetActive(true);
                Pausa = true;

                // Pausar el juego
                Time.timeScale = 0;

                // Mostrar el cursor
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                // Desactivar el script de arma
                if (scriptDeArma != null)
                {
                    scriptDeArma.enabled = false; // Desactiva el script controldearma
                }
            }
        }
    }

    public void Resumir()
    {
        ObejtoMenuPausa.SetActive(false);
        Pausa = false;

        // Reanudar el juego
        Time.timeScale = 1;

        // Ocultar el cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Reactivar el script de arma
        if (scriptDeArma != null)
        {
            scriptDeArma.enabled = true; // Reactiva el script controldearma
        }
    }

    public void iralmenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu);
    }
}