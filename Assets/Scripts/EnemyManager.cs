using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    private const float SpawnMinRange = 0.05f;
    private const float SpawnMaxRange = 0.1f;
    private static float SpawnTimeRange => Random.Range(SpawnMinRange, SpawnMaxRange);
    
    private const float SpawnPosRange = 5f;
    
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    
    private void Start()
    {
        spawnPoints.ForEach(sp =>
        {
            StartCoroutine(SpawnCoroutine(sp));
        });
    }

    private IEnumerator SpawnCoroutine(GameObject spawnPoint)
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTimeRange);
            
            // Spawn enemy
            var position = spawnPoint.transform.position;
            position.x += Random.Range(-SpawnPosRange, SpawnPosRange);
            
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }
}
