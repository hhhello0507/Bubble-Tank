using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private const float ThrowPower = 30f;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunBarrel;

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Running) return;
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            var rigidBody = bullet.GetComponent<Rigidbody>();
            rigidBody.AddForce(gunBarrel.transform.forward * ThrowPower, ForceMode.Impulse);
        }
    }
}
