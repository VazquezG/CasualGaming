using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
    public List<Transform> posiciones = new List<Transform>();
    List<GameObject> coloresEnTubo = new List<GameObject>(4);
    List<int> Indices = new List<int>(4);
    public GameObject colorPureva;
    void Start()
    {
        for(int x = 0; x < 4; x++) {
            coloresEnTubo.Add(null);
            Indices.Add(0);
        }
        coloresEnTubo[0] = Instantiate(colorPureva);
        Indices[0] = 1;
        ponerEnPosicion();
    }

    public void ponerEnPosicion()
    {
        for(int i = 0; i < 4; i++)
        {
            if (coloresEnTubo[i] != null)
            {
                coloresEnTubo[i].transform.position = posiciones[i].position;
            }
        }
    }

    public void ponerColor(int color, GameObject colorObjeto)
    {
        foreach(int i in Indices)
        {
            if(i == 0)
            {
                Indices[i] = color;
                coloresEnTubo[i] = colorObjeto;
                coloresEnTubo[i].transform.position = posiciones[i].position;
                return;
            }
        }

        ponerEnPosicion();
        //si esta lleno
    }

    public void Seleccionado()
    {
        transform.position += new Vector3(0, 1, 0);
        ponerEnPosicion();
    }

    public void Soltar()
    {
        transform.position -= new Vector3(0, 1, 0);
        ponerEnPosicion();
    }

    public int darColorNumeros()
    {
        foreach(int i in Indices)
        {
            if(i != 0)
            {
                int color = Indices[i];
                Indices[i] = 0;
                return color;
            }
        }
        return 0;
    }

    public GameObject darColorObjeto()
    {
        for(int i = 0; i < 4 ; i++)
        {
            if (coloresEnTubo[i] != null) {
                GameObject color = coloresEnTubo[i];
                coloresEnTubo[i] = null;
                return color;
            }
        }
        return null;
    }

}
