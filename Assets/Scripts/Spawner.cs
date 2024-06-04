using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject targetObject;
    public float spawnRate = 10f;
    public float range = 10f;
    private float elapsedTime = 0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (elapsedTime < 55f)
        {
            Vector3 spawnPosition = transform.position;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetTarget(targetObject);
            yield return new WaitForSeconds(spawnRate);
            elapsedTime += spawnRate;
        }
    }
}
