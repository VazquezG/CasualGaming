using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    [SerializeField]
    GameObject jugador, mapa, spawner;
    [SerializeField]
    Canvas canvas, juegoUI;
    private void Start()
    {
        jugador.SetActive(false);
        mapa.SetActive(false);
        spawner.SetActive(false);
        juegoUI.enabled = false;
        canvas.enabled = true;
    }

    public void ClosePanel()
    {
        jugador.SetActive(true);
        mapa.SetActive(true);
        spawner.SetActive(true);
        juegoUI.enabled = true;
        canvas.enabled = false;
    }

    public void OpenPanel()
    {
        jugador.SetActive(false);
        mapa.SetActive(false);
        spawner.SetActive(false);
        spawner.GetComponent<SpawnerEnemigo>().VolvelEmpezar();
        juegoUI.enabled = false;
        canvas.enabled = true;
    }

}
