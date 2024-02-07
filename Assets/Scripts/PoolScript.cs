using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    private List<GameObject> poolsAvailable = new List<GameObject>();
    private List<GameObject> poolsActive = new List<GameObject>();

    [SerializeField]
    GameObject preFabPool;
    [SerializeField]
    int poolCount;
    void Start()
    {
        creaObjetos(poolCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void creaObjetos(int poolCount)
    {
        GameObject temp = new GameObject();
        for(int x = 0; x< poolCount; x++)
        {
            temp = Instantiate(preFabPool, Vector3.zero, Quaternion.identity);
            temp.SetActive(false);
            poolsAvailable.Add(temp);

        }
    }

    public GameObject Request()
    {
        GameObject temp;

        if (poolsAvailable.Count > 0)
        {
            temp = poolsAvailable[0];
            poolsAvailable.RemoveAt(0);
            poolsActive.Add(temp);
            return temp;
        }else
        {
            creaObjetos(1);
            return Request(); 
        }
    }
}
