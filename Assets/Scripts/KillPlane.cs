using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private ZombieManager zombieManager;

    private void Start()
    {
        zombieManager = FindObjectOfType<ZombieManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log(other.name + " hit the KillPlane!");
            zombieManager.ZombieFell();
            other.gameObject.SetActive(false); //hides the zombies
        }
    }
}

