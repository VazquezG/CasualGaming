using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
    public List<Transform> posiciones = new List<Transform>();
    public List<GameObject> coloresEnTubo = new List<GameObject>(4);
    List<int> Indices = new List<int>(4);
    public GameObject colorPureva;

    private void Awake()
    {
        for (int x = 0; x < 4; x++)
        {
            coloresEnTubo.Add(null);
            Indices.Add(0);
        }
    }

    void Start()
    {
       
        //coloresEnTubo[3] = Instantiate(colorPureva);
        //Indices[3] = 1;
        //ponerEnPosicion();
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
        for(int i = 3; i >= 0; i--)
        {

            if (Indices[i] == 0)
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
        //foreach (int i in Indices)
        //{
        //    if (i != 0)
        //    {
        //        int color = Indices[i];
        //        Indices[i] = 0;
        //        return color;
        //    }
        //}

        for(int i = 0; i < 4; i++)
        {
            if (Indices[i] != 0)
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
        for(int i = 0; i < 4  ; i++)
        {
            if (coloresEnTubo[i] != null) {
                GameObject color = coloresEnTubo[i];
                coloresEnTubo[i] = null;
                return color;
            }
        }
        return null;
    }

    public bool completo()
    {
        int chek = Indices[0];
        foreach(int i in Indices)
        {
            if(i != chek)
            {
                return false;
            }
        }
        return true;
    }

    public void empezarDeNuevo()
    {
        for (int x = 0; x < 4; x++)
        {
            coloresEnTubo[x] = null;
            Indices[x] = 0;
        }
    }

}
