using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyState
{
    Default,
    Bubble
}

public class EnemyInfo : MonoBehaviour
{
    private static float PopTimeRange => Random.Range(3f, 9f);
    
    [SerializeField] private GameObject popEffectPrefab;
    
    private EnemyState _state = EnemyState.Default;
    public EnemyState State
    {
        get => _state;
        set
        {
            switch (value)
            {
                case EnemyState.Default:
                    Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
                    break;
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