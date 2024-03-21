using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClicker : MonoBehaviour
{
    [SerializeField]
    List<Transform> positions = new List<Transform>();
    [SerializeField]
    float timer, limit;
    [SerializeField]
    PoolScript pool;
    int rand;
    GameObject hold;
    void Start()
    {
        limit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > limit)
        {
            rand = Random.Range(0, positions.Count);
            hold = pool.Request();
            hold.transform.position = positions[rand].position;
            hold.SetActive(true);
            timer= 0;

        }
    }
}
