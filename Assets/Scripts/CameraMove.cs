using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private readonly Vector3 _offset = new(0, 2f, -4f);

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}