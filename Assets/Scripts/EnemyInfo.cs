using System.Collections;
using UnityEngine;

public enum EnemyState
{
    Default,
    Bubble
}

public class EnemyInfo : MonoBehaviour
{
    private static float PopTimeRange => Random.Range(3f, 9f);

    private EnemyState _state = EnemyState.Default;
    public EnemyState State
    {
        get => _state;
        set
        {
            if (value == EnemyState.Bubble)
            {
                StartCoroutine(PopCoroutine());
            }
            _state = value;
        }
    }

    private IEnumerator PopCoroutine()
    {
        yield return new WaitForSeconds(PopTimeRange);
        _state = EnemyState.Default;
    }
}