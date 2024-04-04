using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TuvosManager : MonoBehaviour
{
    // revisar el mouse
    //revisar despues de vcada movimiento si se gano
    //empezar acabar volver a empezar

    public List<GameObject> allColors = new List<GameObject>();
    public PoolScript Amarillo, Azul, Gris, Naranja, Rojo, Verde; 
    public List<GameObject> tubos = new List<GameObject>();
    PlayerActions action;
    public Colormenu Menu;
    bool selected;
    GameObject hold, colorhold;
    int indexTubos, totalColores;
    void Start()
    {
        selected= false;
        action = new PlayerActions();
        action.Enable();
        action.move.click.performed += sleccionTubo;
        //llenarTubos();
    }

    private void sleccionTubo(InputAction.CallbackContext click)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(action.move.position.ReadValue<Vector2>()), new Vector3(0, 0, 10));

        if(hit.collider == null) {
            if(hold != null)
            {
                hold.GetComponent<Tubo>().Soltar();
                hold = null;
                selected = false;
            }
            return;
        }

        if(hit.collider.tag == "Player")
        {
            //print(hold);
            if (!selected)
            {
                selected = true;
                hold = hit.collider.gameObject;
                hold.GetComponent<Tubo>().Seleccionado();
                
            }
            else
            {
                selected = false;
                if (!hit.collider.GetComponent<Tubo>().lleno())
                {
                    hit.collider.GetComponent<Tubo>().ponerColor(hold.GetComponent<Tubo>().darColorNumeros(), hold.GetComponent<Tubo>().darColorObjeto());

                }
                hold.GetComponent <Tubo>().Soltar();
                hold = null;
                Victoria();
            }
        }

        
    }
  

    public void llenarTubos()
    {
        int ran, ama = 0, azul = 0, gris = 0, nara = 0, rojo = 0, ver = 0;
        //indexTubos = 0;
        //totalColores= 0;
        while(ama != 4 || azul != 4 || gris != 4 || nara != 4 || rojo != 4 || ver != 4)
        {
            if (totalColores % 4 == 0 && totalColores != 0 && indexTubos < tubos.Count)
            {
                indexTubos++;
            }
            ran = Random.Range(1,7);
            switch (ran)
            {
                case 1:
                    
                    if(ama != 4)
                    {
                        
                        colorhold = Amarillo.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold);
                        ama++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;

                case 2:

                    if (azul != 4)
                    {
                        colorhold = Azul.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold); 
                        azul++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;

                case 3:

                    if(gris!= 4)
                    {
                        colorhold = Gris.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold); 
                        gris++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;

                case 4:

                    if (nara != 4)
                    {
                        colorhold = Naranja.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold);
                        nara++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;

                case 5:

                    if(rojo != 4)
                    {
                        colorhold = Rojo.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold); 
                        rojo++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;

                case 6:

                    if(ver != 4)
                    {
                        colorhold = Verde.Request();
                        colorhold.SetActive(true);
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, colorhold); 
                        ver++;
                        totalColores++;
                        allColors.Add(colorhold);
                    }

                    break;
            }
        }

        foreach(GameObject tub in tubos)
        {
            tub.GetComponent<Tubo>().ponerEnPosicion();
        }
        
    }

    private void Victoria()
    {
        foreach(GameObject tub in tubos)
        {
            if(!tub.GetComponent<Tubo>().completo())
            {
                return;
            }
        }
        foreach(GameObject tub in tubos)
        {
            tub.GetComponent<Tubo>().empezarDeNuevo();
        }
        Menu.MenuFinal();
        totalColores = 0;
        indexTubos = 0;
        for(int x = 0; x < allColors.Count; x++)
        {
            allColors[x].GetComponentInParent<PoolScript>().Disapear(allColors[x]);
        }
    }

}
