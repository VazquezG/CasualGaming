using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BloqueTetris : MonoBehaviour
{
    public Vector2 rotationPoint;
    float timercaida, limite;
    public static int height, width;
    private static Transform[,] grid = new Transform[10, 16];
    void Start()
    {
        limite = 0.5f;
        height = 16;
        width = 10;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.hierarchyCount== 0)
        {
            Destroy(gameObject);
        }

        timercaida += Time.deltaTime;
        if (timercaida > limite)
        {
            timercaida = 0;
            transform.position += new Vector3(0, -1, 0);
            if (!validMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                perdio();
                agregarAlGrid();
                checarLineas();
                FindObjectOfType<SpaenerTetromino>().nuevaPieza();
                this.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            if (!validMove())
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) )
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            if(!validMove())
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!validMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            limite = 0.1f;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            limite = 0.5f;
        }
    }

    void perdio()
    {
        foreach (Transform t in transform)
        {
            int x = Mathf.RoundToInt(t.transform.position.x);
            int y = Mathf.RoundToInt(t.transform.position.y);

            if(y > height-3)
            {
                print("gameOver");
            }
        }
    }

    void checarLineas()
    {
        for(int i = height-1; i >= 0; i--)
        {
            if (completeLine(i))
            {
                deleteLine(i);
                rowDown(i);
            }
        }
    }

    bool completeLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if (grid[j, i] == null) {
                return false;
            }
        }
        return true;
    }

    void deleteLine(int i) { 
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j,i].gameObject);
            grid[j,i] = null;
        }
        //rowDown(i);
    }


    void rowDown(int i)
    {
        for(int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                
                if (grid[j,i] != null)
                {
                    print("hola");
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position += new Vector3(0, -1, 0);

                }
                
                
            }
        }
    }

    void agregarAlGrid()
    {
        foreach (Transform t in transform)
        {
            int x = Mathf.RoundToInt(t.transform.position.x);
            int y = Mathf.RoundToInt(t.transform.position.y);

            grid[x,y] = t;
        }
    }

    bool validMove()
    {
        foreach(Transform t in transform)
        {
            int x = Mathf.RoundToInt(t.transform.position.x);
            int y = Mathf.RoundToInt(t.transform.position.y);

            if(x < 0 || x >= width || y < 0 || y >= height)
            {
                return false;
            }
            if (grid[x, y] != null)
            {
                return false;
            }
        }

        
        return true;
    }
}
