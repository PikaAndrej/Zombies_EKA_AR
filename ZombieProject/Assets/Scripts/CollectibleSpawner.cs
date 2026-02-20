using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public Collider spawnArea;
    public float minDelay = 2f;
    public float maxDelay = 4f;
    
    private GameObject currentCollectible;
    private bool isSpawning = false;
    
    void Start()
    {
        SpawnCollectible();
    }

    void Update()
    {
        if (currentCollectible == null && !isSpawning)
        {
            StartCoroutine(SpawnRoutine());
        }
    }

    private IEnumerator SpawnRoutine()
    {
        isSpawning = true;
        float waitTime = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(waitTime);
        SpawnCollectible();
        isSpawning = false;
    }
    private void SpawnCollectible()
    { 
        Bounds bounds = spawnArea.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 spawnPosition = new Vector3(randomX, bounds.max.y, randomZ);
        currentCollectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
    }
}
