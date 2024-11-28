using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateItem : MonoBehaviour
{
    public float fireRateBoost = 2f; // Aumenta la velocidad 2x
    public float boostDuration = 5f; // Dura 5 segundos

    private void OnTriggerEnter(Collider other)
    {
        Gun gun = other.GetComponentInChildren<Gun>();
        if (gun != null)
        {
            gun.IncreaseFireRate(fireRateBoost, boostDuration);
            Destroy(gameObject); // Destruye el ítem tras ser recogido
        }
    }
}