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
    bool selected;
    GameObject hold;
    int indexTubos, totalColores;
    void Start()
    {
        selected= false;
        action = new PlayerActions();
        action.Enable();
        action.move.click.performed += sleccionTubo;
        //llenarTubos();
    }

    void Update()
    {
        
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
            print(hold);
            if (!selected)
            {
                selected = true;
                hold = hit.collider.gameObject;
                hold.GetComponent<Tubo>().Seleccionado();
                
            }
            else
            {
                selected = false;
                hit.collider.GetComponent<Tubo>().ponerColor(hold.GetComponent<Tubo>().darColorNumeros(), hold.GetComponent<Tubo>().darColorObjeto());
                hold.GetComponent <Tubo>().Soltar();
                hold = null;
                
            }
        }

        
    }

    private void llenarTubos()
    {
        int ran, ama = 0, azul = 0, gris = 0, nara = 0, rojo = 0, ver = 0;
        print("entro");
        while(ama != 4 || azul != 4 || gris != 4 || nara != 4 || rojo != 4 || ver != 4)
        {
            print(totalColores);
            if (totalColores % 4 == 0 && totalColores != 0 && indexTubos < tubos.Count)
            {
                print("resando");
                indexTubos++;
            }
            ran = Random.Range(1, 7);
            switch (ran)
            {
                case 1:
                    
                    if(ama != 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Amarillo.Request());
                        ama++;
                        totalColores++;
                        print("amarillo " + ama);
                    }

                    break;

                case 2:

                    if (azul != 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Azul.Request());
                        azul++;
                        totalColores++;
                        print("azul" + azul);
                    }

                    break;

                case 3:

                    if(gris!= 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Gris.Request());
                        gris++;
                        totalColores++;
                        print("Gris" + gris);
                    }

                    break;

                case 4:

                    if (nara != 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Naranja.Request());
                        nara++;
                        totalColores++;
                        print("naranja" + nara);
                    }

                    break;

                case 5:

                    if(rojo != 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Rojo.Request());
                        rojo++;
                        totalColores++;
                        print("rojo" + rojo) ;
                    }

                    break;

                case 6:

                    if(ver != 4)
                    {
                        tubos[indexTubos].GetComponent<Tubo>().ponerColor(ran, Verde.Request());
                        ver++;
                        totalColores++;
                        print("verde" + ver );
                    }

                    break;
            }
        }

        foreach(GameObject tub in tubos)
        {
            tub.GetComponent<Tubo>().ponerEnPosicion();
        }
        
    }

}
