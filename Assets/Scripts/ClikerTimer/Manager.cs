using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Manager : MonoBehaviour
{
    PlayerActions spacio;
    bool tocado;
    float distance;
    Vector2 pos;
    void Start()
    {
        spacio = new PlayerActions();
        spacio.Enable();
        spacio.Jump.salto.performed += saltar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void saltar(InputAction.CallbackContext ctx)
    {
        distance = Mathf.Sqrt(Mathf.Pow(pos.x - transform.position.x , 2) + Mathf.Pow(pos.y - transform.position.y, 2));
        if(tocado && distance < 1)
        {
            Debug.Log("es toda");
        }
        else if(tocado) {
            Debug.Log("puntita");
        }

        if(!tocado)
        {
            Debug.Log("JAJJAJA");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Punto")
        {
            //Debug.Log(collision.tag);
            tocado= true;
            pos = collision.transform.position;
        }
        //if(collision == null)
        //{
        //    tocado= false;
        //    pos = new Vector2(0,0);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tocado= false;
            pos = new Vector2(0, 0);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision!= null)
    //    {
    //        Debug.Log("enterTriger");
    //    }
    //    else
    //    {
    //        Debug.Log("nada Triger");
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision != null)
    //    {
    //        Debug.Log("collisionEnter");
    //    }
    //    else { Debug.Log("nada Coll"); }
    //}
}
