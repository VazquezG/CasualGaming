using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    [SerializeField]
    PoolScript EnemyPool;
    GameObject tempEnemy;
    float timer, limit;
    ManagerPuntos puntos;
    int nivel, tempPuntos;
    bool sumado;
    void Start()
    {
        nivel= 2;
        limit = 1.5f;
        puntos = FindObjectOfType<ManagerPuntos>();
        sumado= true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > limit)
        {
            
            SpawnEnemy();
            timer= 0f;
        }
    }

    public void SpawnEnemy()
    {
        tempEnemy = EnemyPool.Request();
        tempEnemy.transform.position = new Vector3(-12.5f,-3.5f,0);
        tempEnemy.GetComponent<EnemigoVidasMov>().SetVidasEnemigas(nivel);
        tempEnemy.SetActive(true);
        tempEnemy.GetComponent<EnemigoVidasMov>().SetArmour();

        tempPuntos = puntos.getPuntos();

        if (tempPuntos%10 == 0 && nivel < 4 && tempPuntos != 0 && !sumado)
        {

            nivel++;
            limit -= 0.3f;
            sumado= true;
        }
        if(tempPuntos%10 != 0) 
        {
            sumado= false;
        }
        

    }

    public void VolvelEmpezar()
    {
        nivel = 2;
        limit = 1.5f;
        sumado = true;
    }

}
