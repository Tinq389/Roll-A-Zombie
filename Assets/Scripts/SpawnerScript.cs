using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int numberOfGems = 10;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minZ = 4f;
    [SerializeField] private float maxZ = 6f;

    private float[] spawnXPositions = { -6.8f, -3.8f, -0.8f, 2.2f };
    private List<GameObject> gemPool = new List<GameObject>();

    private void Start()
    {
        InitializePool();
        StartCoroutine(SpawnGemsLoop());
    }
    
    private void InitializePool()
    {
        for (int i = 0; i < numberOfGems; i++)
        {
            GameObject gem = Instantiate(gemPrefab);
            gem.SetActive(false); // hide the gem initially
            gemPool.Add(gem);
        }
    }

    // spawning loop
    private IEnumerator SpawnGemsLoop()
    {
        while (true)
        {
            SpawnGem();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnGem()
    {
        GameObject gem = GetPooledGem();
        if (gem == null) return;

        float randomZ = Random.Range(minZ, maxZ);
        float chosenX = spawnXPositions[Random.Range(0, spawnXPositions.Length)];

        Vector3 spawnPosition = new Vector3(chosenX, 10f, randomZ);
        RaycastHit hit;

        if (Physics.Raycast(spawnPosition, Vector3.down, out hit, 20f))
        {
            spawnPosition.y = hit.point.y + 1f;
        }
        else
        {
            spawnPosition.y = 1.5f;
        }

        gem.transform.position = spawnPosition;
        gem.SetActive(true); // reactivate the gem
    }

    // get an inactive gem from the pool
    private GameObject GetPooledGem()
    {
        foreach (GameObject gem in gemPool)
        {
            if (!gem.activeInHierarchy)
            {
                return gem;
            }
        }
        //if no gems -> new gem
        GameObject newGem = Instantiate(gemPrefab);
        newGem.SetActive(false);
        gemPool.Add(newGem);
        return newGem;
    }
    public void CollectGem(GameObject gem)
    {
        gem.SetActive(false); //doesn't get destroyed
    }
}
