using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    Panel panel;
    Vector2 posIni;
    void Start()
    {
        //panel= GetComponent<Panel>();
        rb = GetComponent<Rigidbody2D>();
        gravedad();
        posIni = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void saltoIni()
    {
        rb.gravityScale = 1f;
        rb.velocity = new Vector2(Random.Range(-3, 4), 5);
    }
    private void gravedad()
    {
        rb.gravityScale = 0f;
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Muerte")
        {
            panel.OpenPanel();
            transform.position = posIni;
            rb.velocity = Vector2.zero;
            gravedad();
        }
    }

    private void salto(int dir)
    {
        if(dir == 0)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else if(dir == 1)
        {
            rb.velocity = new Vector2(-3,rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Derecha" || collision.transform.tag == "Izquierda")
        {
            panel.Punto();
        }
        if(collision.transform.tag == "Derecha")
        {
            salto(0);
        }
        else if(collision.transform.tag == "Izquierda")
        {
            salto(1);
        }
    }
}
