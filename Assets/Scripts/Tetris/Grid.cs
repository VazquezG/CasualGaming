using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    GameObject piezaActual;
    float timer, limit;
    void Start()
    {
        limit = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(timer > limit)
        {

        }
        
    }

    private void ActualizarPieza(GameObject nuevaPieza)
    {
        piezaActual = nuevaPieza;
    }

    private void DejarPieza()
    {
        piezaActual = null; 
    }
}
