using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVidasMov : MonoBehaviour
{
    [SerializeField]
    GameObject escudo, armadura;
    Rigidbody2D rb;
    
    public float vel;
    int vidas, limitVidasEnemigos;
    void Start()
    {
        limitVidasEnemigos = 2;
        rb= GetComponent<Rigidbody2D>();
        SetArmour();
        vel = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Morir();
        rb.velocity = new Vector2(1, 0) * vel;   


    }
    public float CuantasVidas()
    {
        return vidas;
    }

    private void Morir()
    {
        switch (vidas)
        {
            case 0:
                SetArmour();
                GetComponentInParent<PoolScript>().Disapear(gameObject);
                break;

            case 1:
                escudo.SetActive(false);
                armadura.SetActive(false);
                break;

            case 2:
                escudo.SetActive(false);
                break;
        }
        
    }

    public void Disparado()
    {
        vidas--;
    }

    public void SetVidasEnemigas(int limit) {
        limitVidasEnemigos = limit;    
    
    }

    public void SetArmour()
    {
        vidas = Random.Range(1, limitVidasEnemigos);
        switch (vidas)
        {
            case 1:
                escudo.SetActive(false);
                armadura.SetActive(false);
                break;

            case 2:
                int rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    escudo.SetActive(true);
                }
                else
                {
                    armadura.SetActive(true);
                }
                break;

            case 3:
                escudo.SetActive(true);
                armadura.SetActive(true);
                break;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Muerte")
        {
            SetArmour();
            GetComponentInParent<PoolScript>().Disapear(gameObject);
        }
    }
}
