using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaenerTetromino : MonoBehaviour
{
    public GameObject[] tetriminoPrefabs;
    GameObject hold;
    void Start()
    {
        hold = Instantiate(tetriminoPrefabs[0]);
        hold.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hold.GetComponent<PiezaTetris>().cayendo)
        {
            int rand = Random.Range(0, tetriminoPrefabs.Length);
            hold = Instantiate(tetriminoPrefabs[rand]);
            hold.transform.position = transform.position;

        }
    }
}
