using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float timeLimit, timeCount, vel;
    PoolScript pool;
    [SerializeField]
    GameObject tuvos;
    GameObject temp;
    float rand;
    void Start()
    {
        pool= GetComponent<PoolScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > timeLimit)
          {
            rand = Random.Range(-1, 1);
            temp = pool.Request();
            temp.SetActive(true);
            temp.transform.position= new Vector2(transform.position.x, rand);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, 0);
            Destroy(temp, 2f);
            timeCount= 0;
        }
    }
}
