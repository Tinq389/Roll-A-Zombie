using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private SpawnerScript spawner;

    private void Start()
    {
        spawner = FindObjectOfType<SpawnerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            ScoreManager.Instance.AddScore(10);

            // call the function to deactivate the gem
            spawner.CollectGem(gameObject);
        }
    }
}