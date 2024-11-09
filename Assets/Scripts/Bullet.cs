using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(10f);
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemyInfo = other.gameObject.GetComponent<EnemyInfo>();
            switch (enemyInfo.State)
            {
                case EnemyInfo.EnemyState.Default:
                    enemyInfo.State = EnemyInfo.EnemyState.Bubble;
                    break;
                case EnemyInfo.EnemyState.Bubble:
                    Destroy(other.gameObject);
                    var gameManager = FindObjectOfType<GameManager>();
                    gameManager.Score += Random.Range(10, 20);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
