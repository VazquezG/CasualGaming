using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log("picado");
        SceneManager.LoadScene(1);
    }
}
