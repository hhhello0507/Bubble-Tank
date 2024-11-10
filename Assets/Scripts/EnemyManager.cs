using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private const float SpawnMinRange = 1f;
    private const float SpawnMaxRange = 2f;
    private static float SpawnTimeRange => Random.Range(SpawnMinRange, SpawnMaxRange);
    
    private const float SpawnPosRange = 5f;
    
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject enemyPrefab;
    
    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
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
