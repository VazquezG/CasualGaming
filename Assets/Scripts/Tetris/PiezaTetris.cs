using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaTetris : MonoBehaviour
{
    public bool cayendo;
    bool movIzq, movDer;
    public Vector2 rotationPoint;
    private float timercaida, limite;
    void Start()
    {
        limite = 0.5f;
        cayendo = true;
        movDer = true;
        movIzq= true;
        rotationPoint = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        //rb.velocity = Vector2.down * speed;
        if (cayendo)
        {
            timercaida += Time.deltaTime;
            if(timercaida > limite)
            {
                timercaida = 0;
                transform.position += new Vector3(0,-1,0);
            }


            if (Input.GetKeyDown(KeyCode.D) && movDer)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            }
            if(Input.GetKeyDown(KeyCode.A) && movIzq) {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }

            if(Input.GetKeyDown(KeyCode.W))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
//                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Piso" || collision.transform.tag == "Pieza")
        {
            cayendo= false;
        }
        if(collision.transform.tag == "ParedIz")
        {
            movIzq = false;
        }
        if(collision.transform.tag == "ParedDe")
        {
            movDer = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "ParedIz")
        {
            movIzq = true;
        }
        if(collision.transform.tag == "ParedDe")
        {
            movDer = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Piso")
        {
            cayendo= false;
        }
    }

}
