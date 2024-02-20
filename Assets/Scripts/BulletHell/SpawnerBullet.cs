using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    GameObject tempBull;
    PlayerVidaPuntos puntosCheck;
    float timeCount;
    int orMin, orMax, rand;
    int combo;
    public float tcambia, tLimit;
    public bool shu;

    [SerializeField]
    float timeLimit;

    [SerializeField]
    PoolScript poolShurikens, poolFlecha;

    [SerializeField]
    List<Transform> posisiones = new List<Transform>();

    
    void Start()
    {
        puntosCheck =FindObjectOfType<PlayerVidaPuntos>();
        combo = 0;
        orMin= 0;
        orMax= 0;
    }

    // Update is called once per frame
    void Update()
    {

        switch (combo)
        {
            case 0:
                esperando();
                break;
            case 1:
                int pos = Random.Range(0, 16);
                shoot(pos);
                combo = 0;
                break;
            case 2:
                FlechasShoot();
                combo = 0;
                break;
            case 3:
                pared();
                combo = 0;
                break;
            case 5:
                if(orMin == 0)
                {
                    orMin = Random.Range(0,10);
                    orMax = 12;
                }
                pasillo();
                combo = 0;
                break;
            case 4:
                paredDesfasada();
                combo = 0;
                break;
        }




    }

    private void esperando()
    {
        puntaje();
        timeCount += Time.deltaTime;
        if(timeCount > timeLimit)
        {
            combo = Random.Range(1, rand);
            timeCount= 0;
        }
    }
    private void puntaje()
    {
        if(puntosCheck.puntos < 10)
        {
            rand = 3;
        }
        else if(puntosCheck.puntos < 20)
        {
            rand = 5;
        }
        else
        {
            rand = 6;
        }
    }

    private void shoot(int t_rando)
    {
        //int pos = Random.Range(0, 16);
        tempBull = poolShurikens.Request();
        tempBull.transform.position = posisiones[t_rando].position;
        tempBull.SetActive(true);
        
    }

    private void FlechasShoot()
    {
        int pos = Random.Range(0, 16);
        tempBull = poolFlecha.Request();
        tempBull.transform.position = posisiones[pos].position;
        tempBull.SetActive(true);
    }

    private void pared()
    {
        int pos = Random.Range(5, 16);
        for (int x = 0; x < posisiones.Count; x++)
        {
            if(x < pos-5 || x > pos)
            {
                shoot(x);
            }

        }
    }

    private void pasillo()
    {
        tcambia += Time.deltaTime;
        if(orMax >= 16)
        {
            combo = 0;
            orMax = 0;
            orMin = 0;
        }
       if(tcambia > tLimit)
        {
            shoot(orMin);
            shoot(orMax);
            orMax++;
            orMin++;
            tcambia= 0;
        }
        
        
    }

    private void paredDesfasada()
    {
        int pos = Random.Range(0, 12);
        for (int x = pos; x < pos + 5;x++)
        {
            shoot(x);
        }
    }

}
