using System.Collections;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public enum EnemyState
    {
        Default,
        Bubble
    }
    private static float PopTimeRange => Random.Range(3f, 9f);

    private EnemyState _state = EnemyState.Default;
    public EnemyState State
    {
        get => _state;
        set
        {
            switch (value)
            {
                case EnemyState.Bubble:
                    StartCoroutine(PopCoroutine());
                    break;
                default:
                    break;
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