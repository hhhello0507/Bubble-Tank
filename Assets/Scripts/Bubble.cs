using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bubble : MonoBehaviour
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
                case EnemyState.Default:
                    enemyInfo.State = EnemyState.Bubble;
                    break;
                case EnemyState.Bubble:
                    Destroy(other.gameObject);
                    GameManager.Instance.Score += Random.Range(10, 20);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
