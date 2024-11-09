using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float _moveSpeed = 3f;

    private GameObject _player;
    private EnemyInfo _enemyInfo;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    private float _yVelocity;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _enemyInfo = FindObjectOfType<EnemyInfo>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (_enemyInfo.State)
        {
            case EnemyInfo.EnemyState.Default:
                _moveDirection = (_player.transform.position - transform.position).normalized;
                _moveSpeed = 3f;
                _rigidbody.useGravity = true;
                _rigidbody.isKinematic = false;
                break;
            case EnemyInfo.EnemyState.Bubble:
                _moveDirection = Vector3.up;
                _moveSpeed = 1f;
                _rigidbody.useGravity = false;
                _rigidbody.isKinematic = true;
                break;
            default:
                break;
        }

        transform.position += _moveDirection * (_moveSpeed * Time.deltaTime);
    }
}