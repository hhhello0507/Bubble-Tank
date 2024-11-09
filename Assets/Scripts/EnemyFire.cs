using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private PlayerInfo _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerInfo>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 2f)
        {
            _player.Hp -= 10;
            Destroy(gameObject);
        }
    }
}