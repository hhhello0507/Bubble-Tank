using System;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerInfo = FindObjectOfType<PlayerInfo>();
            playerInfo.Hp -= 10;
            Destroy(gameObject);
        }
    }
}