using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balastorreta : MonoBehaviour

{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _timer = 2f;
    private float timerCount = 0f;

    [SerializeField]
    private int _counter;
    private int _maxcounter = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullets_CR());
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coroutine");
        for(int i=0; i< _maxcounter; i++)
        {
            _counter++;
            Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer);

        }
        Debug.Log("Fin coroutine");
    }
}
