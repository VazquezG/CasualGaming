using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenMove : MonoBehaviour
{
    public float vel;
    Vector3 direccion;
    Rigidbody2D rb;
    float timer, tCount;
    public bool solo;
    void Start()
    {
        CambiarDireccion();
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
        tCount = 4;
    }

    // Update is called once per frame
    void Update()
    {

        if(solo)
        {
            timer += Time.deltaTime;
            if (timer > tCount)
            {
                GetComponentInParent<PoolScript>().Disapear(gameObject);
                timer = 0;

            }
        }
        
        rb.velocity = direccion * vel;
        transform.Rotate(Vector3.forward * 10);
        
    }

    private void CambiarDireccion()
    {
        if(transform.position.x > 9)
        {
            direccion = new Vector3(-1,0,0);
        }

        if(transform.position.x < -9)
        {
            direccion = new Vector3(1, 0, 0);
        }

        if (transform.position.y > 6)
        {
            direccion = new Vector3(0, -1, 0);
        }

        if (transform.position.y < -6)
        {
            direccion = new Vector3(0, 1, 0);
        }
    }
}
