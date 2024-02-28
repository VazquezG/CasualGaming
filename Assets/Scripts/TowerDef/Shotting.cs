using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shotting : MonoBehaviour
{
    PlayerActions actions;
    bool disparando, recargando, sumado;
    [SerializeField]
    GameObject fuego;
    float timer, limitimer, limitimerFuego, limitimeRecarga;
    ManagerPuntos puntos;
    void Start()
    {
        puntos = FindObjectOfType<ManagerPuntos>();
        //puntos.RecargarBalas();
        sumado = true;
        limitimer = 0.2f;
        limitimerFuego = 0.5f;
        limitimeRecarga = 2;
        timer= 0;
        fuego.SetActive(false);
        actions = new PlayerActions();
        actions.Enable();
        actions.move.click.performed += Shoot ;

    }

    // Update is called once per frame
    void Update()
    {
        if (disparando )
        {
            timer += Time.deltaTime;

        }

        ////if(recargando)
        ////{
        ////    limitimer = LimiteRecarga();
        ////}
        ////else
        ////{
        ////    limitimer = 0.2f;
        ////}

        limitimer = LimiteRecarga();

        if (timer > limitimer)
        {
            disparando = false;
            fuego.SetActive(false);
            recargando = false;
            timer = 0;

        }
    }

    private float LimiteRecarga()
    {
        if(puntos.getPuntos()%10 == 0 && limitimeRecarga > 0.5f && !sumado)
        {
            limitimeRecarga -= 0.5f;
            limitimerFuego -= 0.1f;
            sumado = true;
        }
        if(puntos.getPuntos()%10 != 0)
        {
            sumado = false;
        }
        if(recargando)
        {
            return limitimeRecarga;
        }
        else
        {
            return limitimerFuego;
        }
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        if (!disparando)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(actions.move.position.ReadValue<Vector2>()), new Vector3(0, 0, 10));
            disparando = true;
            fuego.SetActive(true);
            puntos.RestaBala();


            if (hit.collider != null && hit.collider.tag == "Punto")
            {
                hit.collider.GetComponent<EnemigoVidasMov>().Disparado();
                if (hit.collider.GetComponent<EnemigoVidasMov>().CuantasVidas() == 0)
                {
                    puntos.sumaPuntos();
                }

            }
            if(puntos.getBalas() == 0)
            {
                recargando= true;
                puntos.RecargarBalas();
            }

        }


        
    }
}
