using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerVidaPuntos : MonoBehaviour
{
    public int puntos;
    [SerializeField]
    TMP_Text puntuacion;
    [SerializeField]
    GameObject Spawners;

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = Convert.ToString(puntos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Punto")
        {
            puntos++;
        }

        if(collision.tag == "Muerte")
        {
            //GetComponent<PlayerMovement>().enabled= false;
            //GetComponent<PlayerVidaPuntos>().enabled= false;
            //Spawners.SetActive(false);
            Debug.Log("!!!MUERTE!!!");
        }
    }
}
