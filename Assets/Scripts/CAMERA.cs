using UnityEngine;

public class CameraAndPlayerControl : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public Transform cameraHolder; // Objeto que contiene la cámara (puede ser el mismo que este script)
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public float verticalClamp = 80f; // Límite para la rotación vertical

    private float verticalRotation = 0f; // Almacena la rotación vertical acumulada

    void Start()
    {
        // Bloquea y oculta el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Captura el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación horizontal: aplica al jugador
        player.Rotate(Vector3.up * mouseX);

        // Rotación vertical: aplica al cámara (clamp para evitar giros locos)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClamp, verticalClamp);
        cameraHolder.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

}
