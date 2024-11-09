using System.Collections;
using UnityEngine;

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
}
