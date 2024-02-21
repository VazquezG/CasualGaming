using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    GameObject tempBull;
    float timeCount;
    int orMin, orMax, rand;
    int combo;
    public float tcambia, tLimit;

    [SerializeField]
    PlayerVidaPuntos puntosCheck;

    float tiempoLimiteAccion;

    [SerializeField]
    PoolScript poolShurikens, poolFlecha, poolOla;

    [SerializeField]
    List<Transform> posisiones = new List<Transform>();

    
    void Start()
    {
        combo = 0;
        orMin= 0;
        orMax= 0;
    }

    // Update is called once per frame
    void Update()
    {

        //switch (combo)
        //{
        //    case 0:
        //        esperando();
        //        break;
        //    case 1:
        //        int pos = Random.Range(0, 16);
        //        shoot(pos);
        //        combo = 0;
        //        break;
        //    case 2:
        //       // FlechasShoot();
        //        combo = 0;
        //        break;
        //    case 3:
        //        //pared();
        //        combo = 0;
        //        break;
        //    case 5:
        //        if(orMin == 0)
        //        {
        //            orMin = Random.Range(0,10);
        //            orMax = 12;
        //        }
        //        //pasillo();
        //        combo = 0;
        //        break;
        //    case 4:
        //        //paredDesfasada();
        //        combo = 0;
        //        break;
        //}




    }

    private void esperando()
    {
        timeCount += Time.deltaTime;
        if(timeCount > tiempoLimiteAccion)
        {
            combo = Random.Range(1, rand);
            timeCount= 0;
        }
    }
    

    public void shoot(int t_rando)
    {
        tempBull = poolShurikens.Request();
        tempBull.transform.position = posisiones[t_rando].position;
        tempBull.SetActive(true);
        
    }

    public void FlechasShoot(int pos)
    {
        tempBull = poolFlecha.Request();
        tempBull.transform.position = posisiones[pos].position;
        tempBull.SetActive(true);
    }

    public void pared(int pos)
    {
        for (int x = 0; x < posisiones.Count; x++)
        {
            if(x < pos-5 || x > pos)
            {
                shoot(x);
            }

        }
    }

    public void pasillo(int posMin)
    {

        tempBull = poolOla.Request();
        tempBull.transform.position = posisiones[posMin].position;
        tempBull.SetActive(true);
        tempBull = poolOla.Request();
        tempBull.transform.position = posisiones[posMin-7].position;
        tempBull.SetActive(true);



    }

    public void paredDesfasada(int pos)
    {
        tempBull = poolOla.Request();
        tempBull.transform.position = posisiones[pos].position;
        tempBull.SetActive(true);
    }

}
