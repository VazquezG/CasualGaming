using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    int puntuacion;
    [SerializeField]
    Trampolin trampo;
    [SerializeField]
    Canvas Menu, gameplay;
    private void Awake()
    {
        OpenPanel();
    }

    public void ClosePanel()
    {
        trampo.enabled = true;
        Menu.enabled = false;
        gameplay.enabled = true;
    }

    public void OpenPanel()
    {
        trampo.enabled = false;
        Menu.enabled = true;
        gameplay.enabled = false;
        puntuacion = 0;
        puntos.text = puntuacion.ToString();
    }

    public void Punto()
    {
        puntuacion++;
        puntos.text = puntuacion.ToString();
    }
}
