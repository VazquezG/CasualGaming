using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VueloFlappy : MonoBehaviour
{
    [SerializeField]
    float vel;
    [SerializeField]
    Rigidbody2D rb;
    void Start()
    {
       // rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0,vel);
        }
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Tuvo"))
        {
            gameObject.SetActive(false);
        }
    }
}
