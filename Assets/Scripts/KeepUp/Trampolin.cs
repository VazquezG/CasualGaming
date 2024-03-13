using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trampolin : MonoBehaviour
{
    PlayerActions accion;
    [SerializeField]
    GameObject trampolin;
    bool prendido;
    float timer, limit;
    GameObject elTrampolin;
    Vector3 pos;
    void Start()
    {
        limit = 1;
        //
        elTrampolin = Instantiate(trampolin);
        elTrampolin.SetActive(false);
        accion = new PlayerActions();
        accion.Enable();
        accion.move.click.performed += PonerTrampolin;
    }

    // Update is called once per frame
    void Update()
    {
        if(prendido)
        {
            timer += Time.deltaTime;
            if(timer > limit)
            {
                Debug.Log("quitalo");
                elTrampolin.SetActive(false);
                prendido= false;
                timer= 0;
            }
        }
    }

    private void PonerTrampolin(InputAction.CallbackContext ctx)
    {
        Debug.Log("ponlo");
        elTrampolin.SetActive(true);
        pos = Camera.main.ScreenToWorldPoint(accion.move.position.ReadValue<Vector2>());
        pos = new Vector3(pos.x, pos.y, 0);
        elTrampolin.transform.position = pos;
            //Camera.main.ScreenToWorldPoint(accion.move.position.ReadValue<Vector2>());
        prendido= true; 
    }
}
