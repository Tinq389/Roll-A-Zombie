using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour
{
    public Transform table;
    
    void Start()
    {
        
    }

    public void RotateTable(float x, float z)
    {
        Vector3 rotation = new Vector3(x, 0, z) * 10 * Time.deltaTime;
        table.Rotate(rotation, Space.World);
    }
    void Update()
    {
        if (Input.GetKey("left"))
            RotateTable(0, 1);
        if (Input.GetKey("right"))
            RotateTable(0, -1);
        if (Input.GetKey("up"))
            RotateTable(1,0);
        if (Input.GetKey("down"))
            RotateTable(-1,0);
    }
}
