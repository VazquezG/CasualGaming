using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : MonoBehaviour
{
    ManagerPuntos vidas;
    void Start()
    {
        vidas = FindObjectOfType<ManagerPuntos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Punto")
        {
            vidas.quitarvida();
        }
    }
}
