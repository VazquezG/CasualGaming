using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movimiento : MonoBehaviour
{
   
    Vector3 target, desireVel;
    [SerializeField]
    float maxVel, slowDistance, slowingForce, slowing, distance;
    void Start()
    {
        //maxVel = 0;
        //slowDistance = 0;
        //slowingForce = 0;
        target = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target)
        {
            Moverse();
        }
        else
        {
            GetComponentInParent<PoolScript>().Disapear(gameObject);
            transform.position = new Vector3(10,10,0); 
        }
    }

    private void Moverse()
    {
        /// este codigo lo recicle de la clase de Inteligencia Artifical de Vald Vectores
        desireVel = target - transform.position;
        desireVel.Normalize();
        desireVel *= maxVel;
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - target.x, 2) + Mathf.Pow(transform.position.y - target.y, 2));
        if (distance < slowDistance)
        {
            slowing = distance / slowingForce;
            desireVel *= slowing;
        }
        transform.position += desireVel;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        Debug.Log("algo");
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.transform.tag == "Player")
    //    {
    //        Debug.Log("algo Coll");
    //    }
    //}


}
