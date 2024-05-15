using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public GameObject canvaMenu, CanvaGO, puntos, spawn;
    public TextMeshProUGUI totalPuntos;
    int puntosCount;
    void Start()
    {
        puntosCount = 0;
        CanvaGO.SetActive(false);
        spawn.SetActive(false);
        puntos.SetActive(false);
    }

    public void Perdio()
    {
        CanvaGO.SetActive(true);
        spawn.SetActive(false);
    }

    public void jugar()
    {
        puntos.SetActive(true);
        canvaMenu.SetActive(false);
        CanvaGO.SetActive(false);
        spawn.SetActive(true);
    }

    public void volverEmpezar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void sumaPuntos(int num)
    {
        puntosCount += num;
        totalPuntos.text = puntosCount.ToString();
    }
}
