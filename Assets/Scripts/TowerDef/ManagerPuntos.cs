using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerPuntos : MonoBehaviour
{
    [SerializeField]
    TMP_Text puntuacion, Cartucho, vidas;
    int puntos, balas, maxBalas, vidasNum;
    bool sumado;
    PanelScript menu;
    void Start()
    {
        menu = FindObjectOfType<PanelScript>();
        vidasNum = 5;
        balas = 6;
        maxBalas = 5;
        sumado = true;
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = Convert.ToString(puntos);
        Cartucho.text = Convert.ToString(balas);
        vidas.text = Convert.ToString(vidasNum);
        if(puntos%5 == 0 && maxBalas < 30 && !sumado)
        {
            SumarCapacidad();
            sumado= true;
        }
        if(puntos%5 != 0) 
        {
            sumado= false;
        }

        if(vidasNum == 0) {
            
            vidasNum = 5;
            balas = 6;
            maxBalas = 5;
            puntos = 0;
            sumado = true;
            menu.OpenPanel();
        }
    }
    public void quitarvida()
    {
        vidasNum--;
    }

    public void sumaPuntos()
    {
        puntos++;
    }

    public void RestaBala()
    {
        balas--;
    }

    public void RecargarBalas()
    {
        balas = maxBalas;
    }

    public void SumarCapacidad()
    {
        maxBalas += 5;
    }

    public int getBalas()
    {
        return balas;
    }

    public int getPuntos()
    {
        return puntos;
    }

    public int getVidasNum()
    {
        return vidasNum;
    }
}
