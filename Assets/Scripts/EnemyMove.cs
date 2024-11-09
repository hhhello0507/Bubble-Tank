using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private const float MoveSpeed = 3f;
    
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        var direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * (MoveSpeed * Time.deltaTime);
    }
}
