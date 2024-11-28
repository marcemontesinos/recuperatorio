using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    Rigidbody bulletRb;

    public float power = 100f;
    public float lifeTime = 4f;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        bulletRb.velocity = this.transform.forward * power;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;


        if (time >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
