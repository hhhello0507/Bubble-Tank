using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private const float Gravity = -9.8f;

    private float _moveSpeed = 3f;

    private GameObject _player;
    private EnemyInfo _enemyInfo;
    private Vector3 _moveDirection;
    private CharacterController _controller;
    private NavMeshAgent _navMeshAgent;
    private GameObject _bubble;
    private float _yVelocity;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _enemyInfo = FindObjectOfType<EnemyInfo>();
        _controller = GetComponent<CharacterController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _bubble = transform.Find("Bubble").gameObject;
    }

    private void Update()
    {
        if (transform.position.y < 1f)
        {
            _navMeshAgent.enabled = true;
            _yVelocity = 0f;
        }

        switch (_enemyInfo.State)
        {
            case EnemyState.Default:
                _moveDirection = (_player.transform.position - transform.position).normalized;
                _moveSpeed = 3f;

                _yVelocity += Gravity * Time.deltaTime;
                _moveDirection.y = _yVelocity;

                if (_navMeshAgent.enabled)
                {
                    _navMeshAgent.destination = _player.transform.position;
                }
                
                _bubble.SetActive(false);
                break;
            case EnemyState.Bubble:
                _moveDirection = Vector3.up;
                _moveSpeed = 1f;
                _navMeshAgent.enabled = false;
                _yVelocity = 0f;
                _bubble.SetActive(true);
                break;
            default:
                break;
        }
        
        transform.position += _moveDirection * (_moveSpeed * Time.deltaTime);
    }
}