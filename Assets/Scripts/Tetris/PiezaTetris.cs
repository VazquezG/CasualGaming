using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaTetris : MonoBehaviour
{
    public bool cayendo;
    bool movIzq, movDer;
    public Vector2 rotationPoint;
    private float timercaida, limite;
    public Collider2D[] futuro;
    private int queCol;
    void Start()
    {
        
        limite = 0.5f;
        cayendo = true;
        movDer = true;
        movIzq= true;
        rotationPoint = Vector2.zero;
        empezar();
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
            print(gameObject.name);
            if(Input.GetKeyDown(KeyCode.W) && movDer && movIzq)
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                checkPiezaColliders();  
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Piso" /*|| collision.transform.tag == "Pieza"*/)
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
        print("si");
        if(collision.tag == "Pieza")
        {
            cayendo= false;
        }
    }

    private void empezar()
    {
        if(gameObject.name == "I(clone)" || gameObject.name == "O(clone)" || gameObject.name == "J(clone)" || gameObject.name == "L(clone)")
        {
            foreach (Collider2D f in futuro)
            {
                f.enabled = (false);
            }
            futuro[0].enabled = (true);
            queCol= 0;
        }
        else if(gameObject.name == "S(clone)" || gameObject.name == "Z(clone)")
        {
            foreach (Collider2D f in futuro)
            {
                f.enabled = (false);
            }
            futuro[0].enabled = (true);
            futuro[1].enabled = (true);
            queCol = 1;
        }
        else if(gameObject.name == "T(clone)")
        {
            foreach (Collider2D f in futuro)
            {
                f.enabled = (false);
            }
            futuro[0].enabled = (true);
            futuro[1].enabled = (true);
            futuro[2].enabled = (true); 
            queCol = 2;
        }
        
    }

    private void checkPiezaColliders()
    {
        switch (gameObject.name)
        {
            case "I(clone)":
                futuro[queCol].enabled = (false);
                if (queCol < futuro.Length - 1)
                {
                    queCol++;
                }
                else
                {
                    queCol = 0;
                }

                futuro[queCol].enabled = (true);
                break;
            case "O(clone)":
                futuro[queCol].enabled = (false);
                if (queCol < futuro.Length - 1)
                {
                    queCol++;
                }
                else
                {
                    queCol = 0;
                }

                futuro[queCol].enabled = (true);
                break;
            case "J(clone)":
                if(queCol == 2 || queCol == 4)
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = (false);
                }
                if(queCol < futuro.Length - 1)
                {
                    futuro[queCol].enabled = (false);
                    queCol++;
                    if(queCol == 1 || queCol == 3)
                    {
                        futuro[queCol].enabled = (true) ;
                        queCol++;
                    }
                    
                }
                else
                {
                    queCol= 0;
                }
                futuro[queCol].enabled = (true);
                break;
            case "L(clone)":
                if (queCol == 3 || queCol == 5)
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = (false);
                }
                if (queCol < futuro.Length - 1)
                {
                    futuro[queCol].enabled = (false);
                    queCol++;
                    if (queCol == 2 || queCol == 4)
                    {
                        futuro[queCol].enabled = (true);
                        queCol++;
                    }

                }
                else
                {
                    queCol = 0;
                }
                futuro[queCol].enabled = (true);
                break;
            case "S(clone)":
                
                if(queCol < futuro.Length - 1)
                {
                    futuro[queCol-1].enabled = (false);
                    futuro[queCol].enabled = (false);
                    queCol++;
                    futuro[queCol].enabled = (true);
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                else
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = (false);
                    queCol = 0;
                    futuro[queCol].enabled = (true);
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                break;
            case "Z(clone)":
                if (queCol < futuro.Length - 1)
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = (false);
                    queCol++;
                    futuro[queCol].enabled = (true);
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                else
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = (false);
                    queCol = 0;
                    futuro[queCol].enabled = (true);
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                break;
            case "T(clone)":
                if (queCol == futuro.Length - 1)
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol].enabled = false;
                    futuro[0].enabled = (true);
                    futuro[1].enabled = (true);
                    futuro[2].enabled = (true);
                    queCol = 2;
                }
                else if (queCol == 2)
                {
                    futuro[queCol - 1].enabled = (false);
                    futuro[queCol - 2].enabled = (false);
                    futuro[queCol].enabled = (false);
                    queCol++;
                    futuro[queCol].enabled = (true);
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                else if(queCol == 4)
                {
                    futuro[queCol-1].enabled = (false);
                    futuro[queCol+1].enabled = (false);
                    queCol++;
                    futuro[queCol].enabled = true;
                }
                else if(queCol==5)
                {
                    futuro[queCol].enabled= (false);
                    queCol++;
                    futuro[queCol].enabled = true;
                    queCol++;
                    futuro[queCol].enabled = (true);
                }
                
                break;
        }
    }


}
