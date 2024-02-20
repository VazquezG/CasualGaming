using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 target, desireVel, targetPrueva;
    [SerializeField]
    float maxVel, slowingForce, slowDistance;
    float distance, slowing;
    PlayerActions action;
    private void Awake()
    {
        action = new PlayerActions();
    }

    void Start()
    {
        target= transform.position;
        action.Enable();
        action.move.click.performed += Moverse;
        
    }

    
    void Update()
    {
        if(transform.position != target)
        {
            Caminar();
        }
    }

    private void Caminar()
    {
        /// este codigo lo recicle de la clase de Inteligencia Artifical de Vald Vectores
        desireVel = target - transform.position;
        desireVel.Normalize();
        desireVel *= maxVel;
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - target.x, 2) + Mathf.Pow(transform.position.y - target.y, 2));
        if(distance < slowDistance)
        {
            slowing = distance / slowingForce;
            desireVel *= slowing;
        }
        transform.position += desireVel;
    }

    private void Moverse(InputAction.CallbackContext ctx)
    {

        targetPrueva = Camera.main.ScreenToWorldPoint(action.move.position.ReadValue<Vector2>());
        if(-7.3 < targetPrueva.x && targetPrueva.x < 7.3)
        {
            target = targetPrueva;
        }
        target.z = 0;
    }
}
