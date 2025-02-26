using System;
using Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 selectedSize, normalSize; 
    private int selectedIndex;
    void Start()
    {
        GameObject toSelect = zombies[0];
        SelectZombie(toSelect);
    }

    private void SelectZombie(GameObject toSelect)
    {
        if(selectedZombie != null)
            selectedZombie.transform.localScale = normalSize;
        selectedZombie = toSelect;
        selectedZombie.transform.localScale = selectedSize;
        selectedIndex = Array.IndexOf(zombies,toSelect);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PushUp();
        }
    }

    public void SelectRight()
    {
        Debug.Log("select right");
        selectedIndex++;
        if (selectedIndex >= zombies.Length)
            selectedIndex = 0;
        SelectZombie(zombies[selectedIndex]);
    }
    
    public void SelectLeft()
    {
        Debug.Log("select left");
        selectedIndex--;
        if (selectedIndex <0)
            selectedIndex = zombies.Length - 1;
        SelectZombie(zombies[selectedIndex]);
    }

    public void PushUp()
    {
        Debug.Log("push up");
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 3, ForceMode.Impulse);
    }
}
