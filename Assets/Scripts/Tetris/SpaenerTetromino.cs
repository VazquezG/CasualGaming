using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaenerTetromino : MonoBehaviour
{
    //public static SpaenerTetromino instance;
    public GameObject[] tetriminoPrefabs;
    GameObject hold;
    
    void Start()
    {
        nuevaPieza();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nuevaPieza()
    {
        int rand = Random.Range(0, tetriminoPrefabs.Length);
        hold = Instantiate(tetriminoPrefabs[rand]);
        hold.transform.position = transform.position;
    }
}
