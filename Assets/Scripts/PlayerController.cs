using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // Velocidad normal del jugador
    private float normalSpeed;
    private float speedBoostDuration = 10f;
    [Header("References")]
    public Camera playerCamera;

    [Header ("Movement")]
    public float Speed;
    [Header("Jump")]
    public float JumpHeight = 1.9f;
    [Header("General")]
    public float GravityScale = -20f;
    [Header("Rotation")]
    public float rotationsensibility = 10f;

    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();


    }
    void Start()
    {
        normalSpeed = speed;
    }
    private void Update()
    {
        if (speedBoostDuration > 0)
        {
            speedBoostDuration -= Time.deltaTime;
            if (speedBoostDuration <= 0)
            {
                ResetSpeed(); // Vuelve a la velocidad normal
            }
        }
        Look();
        Move();
    }
    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = transform.TransformDirection(moveInput) * Speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(JumpHeight * -2f * GravityScale);

            }

        
        }

        moveInput.y += GravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);   

    }
    private void Look()
    {
        
        









    }
    public IEnumerator SpeedBoost(float amount, float duration)
    {
        speed *= amount;  // Aumenta la velocidad
        yield return new WaitForSeconds(duration);  // Espera durante el tiempo especificado
        speed = normalSpeed;  // Restaura la velocidad normal
    }

    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        speed += boostAmount;
        speedBoostDuration = duration;
    }

    // Método para restaurar la velocidad normal
    private void ResetSpeed()
    {
        speed = normalSpeed; // Velocidad original
    }

    
}

