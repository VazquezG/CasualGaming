using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance;
    public Transform[,] grid;
    void Start()
    {
        grid = new Transform[10, 16];
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }

    public void addToGrid(int x, int y, Transform child)
    {
        grid[x, y] = child;
    }
}
