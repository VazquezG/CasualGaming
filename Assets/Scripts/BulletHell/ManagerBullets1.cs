using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBullets1 : MonoBehaviour
{
    int poolActivas, laPool, queDispara, disparosActivos, posDisparo;
    float timeChek, timeLimit;
    [SerializeField]
    PlayerVidaPuntos puntosCheck;
    [SerializeField]
    List<SpawnerBullet> spawns= new List<SpawnerBullet>();
    
    void Start()
    {
        timeLimit = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeChek += Time.deltaTime;
        if(timeChek > timeLimit)
        {
            Accion();
            timeChek= 0;
        }
    }

    private void Accion()
    {
        ChecarPuntosShoot();
        poolActivas = ChecarPuntosPools() ;
        laPool = Random.Range(0,poolActivas) ;
        queDispara = Random.Range(0,2) ;
        if(laPool < 2)
        {
            posDisparo = Random.Range(0, 16);
        }
        else
        {
            posDisparo= Random.Range(0, 26);
        }

        switch(queDispara)
        {
            case 0 :
                spawns[laPool].FlechasShoot(posDisparo);
                break;
            case 1 :
                spawns[laPool].shoot(posDisparo) ;
                break;
            case 2 :
                if(posDisparo < 6)
                {
                    posDisparo = 6;
                }
                spawns[laPool].pared(posDisparo);
                break;
            case 3 :
                if(posDisparo > 10 && laPool < 2) 
                { 
                    posDisparo = 10;
                }
                else if(posDisparo > 20 && laPool >= 2)
                {
                    posDisparo = 20;
                }
                spawns[laPool].paredDesfasada(posDisparo);
                break;

        }

    }

    private int ChecarPuntosPools()
    {
        if(puntosCheck.puntos >= 25)
        {
            return 4;
        }
        if(puntosCheck.puntos >= 15)
        {
            return 3;
        }
        if(puntosCheck.puntos >= 5)
        {
            return 2;
        }
        return 1;
    }

    private void ChecarPuntosShoot()
    {
        if(puntosCheck.puntos == 0)
        {
            timeLimit = 1.8f;
        }
        if(puntosCheck.puntos%5 == 0 && timeLimit > 0.9f)
        {
            timeLimit -= 0.3f;
        }
    }

}
