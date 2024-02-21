using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVidaPuntos : MonoBehaviour
{
    public int puntos;
    [SerializeField]
    TMP_Text puntuacion;
    [SerializeField]
    GameObject Spawners;
    bool muerto;
    float timer, limit;

    private void Start()
    {
        muerto= false;
        limit = 2;
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = Convert.ToString(puntos);
        if(muerto)
        {
            Debug.Log("muerto");
            timer += Time.deltaTime;
            if(timer > limit)
            {
                Debug.Log("ranaso");
                SceneManager.LoadScene(0);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Punto")
        {
            puntos++;
        }

        if(collision.tag == "Muerte")
        {
            GetComponent<PlayerMovement>().enabled= false;
            //GetComponent<PlayerVidaPuntos>().enabled= false;
            GetComponent<BoxCollider2D>().enabled= false;
            Spawners.SetActive(false);
            muerto = true;
            
        }
    }
}
