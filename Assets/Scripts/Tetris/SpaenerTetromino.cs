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
        //if (!hold.GetComponent<PiezaTetris>().cayendo)
        //{
        //    int rand = Random.Range(0, tetriminoPrefabs.Length);
        //    hold = Instantiate(tetriminoPrefabs[0]);
        //    hold.transform.position = transform.position;

        //}
    }

    public void nuevaPieza()
    {
        int rand = Random.Range(0, tetriminoPrefabs.Length);
        hold = Instantiate(tetriminoPrefabs[rand]);
        hold.transform.position = transform.position;
    }
}
