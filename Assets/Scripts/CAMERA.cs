using UnityEngine;

public class CameraAndPlayerControl : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public Transform cameraHolder; // Objeto que contiene la c�mara (puede ser el mismo que este script)
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public float verticalClamp = 80f; // L�mite para la rotaci�n vertical

    private float verticalRotation = 0f; // Almacena la rotaci�n vertical acumulada

    void Start()
    {
        // Bloquea y oculta el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Captura el movimiento del rat�n
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotaci�n horizontal: aplica al jugador
        player.Rotate(Vector3.up * mouseX);

        // Rotaci�n vertical: aplica al c�mara (clamp para evitar giros locos)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClamp, verticalClamp);
        cameraHolder.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

}
