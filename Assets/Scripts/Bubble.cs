using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bubble : MonoBehaviour
{
    [SerializeField] private GameObject popEffectPrefab;

    private void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.volume = 3.0f;
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Level"))
        {
            var killingColliders = Physics.OverlapSphere(transform.position, 5f);

            foreach (var o in killingColliders
                         .Where(c => c.gameObject.CompareTag("Enemy"))
                         .Select(c => c.gameObject))
            {
                Instantiate(popEffectPrefab, o.transform.position, Quaternion.identity);
                KillEnemy(o);
            }

            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void KillEnemy(GameObject enemy)
    {
        Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
        var enemyInfo = enemy.GetComponent<EnemyInfo>();
        switch (enemyInfo.State)
        {
            case EnemyState.Default:
                enemyInfo.State = EnemyState.Bubble;
                break;
            case EnemyState.Bubble:
                Destroy(enemy);
                GameManager.Instance.Score += Random.Range(10, 20);
                break;
            default:
                break;
        }
    }
}