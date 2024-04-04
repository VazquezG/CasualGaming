using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colormenu : MonoBehaviour
{
    public GameObject MenuPrincipal, MenuVictoria;
    public List<GameObject> tubos= new List<GameObject>();
    public TuvosManager tuvosManager;
    void Start()
    {
        foreach (GameObject go in tubos)
        {
            go.SetActive(false);
        }
        MenuVictoria.SetActive(false);
    }

    public void EmpezarJuego()
    {
        foreach (GameObject go in tubos)
        {
            go.SetActive(true);
        }
        MenuVictoria.SetActive(false);
        MenuPrincipal.SetActive(false);
        tuvosManager.llenarTubos();
    }

    public void MenuFinal()
    {
        foreach (GameObject go in tubos)
        {
            go.SetActive(false);
        }
        MenuVictoria.SetActive(true);
    }
}
