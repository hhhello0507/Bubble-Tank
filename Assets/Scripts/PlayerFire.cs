using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFire : MonoBehaviour
{
    private const float ThrowPower = 30f;
    
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private GameObject gunBarrel;

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Running) return;
        if (Input.GetMouseButtonDown(0))
        {
            var bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            
            var rigidBody = bubble.GetComponent<Rigidbody>();
            rigidBody.AddForce(gunBarrel.transform.forward * ThrowPower, ForceMode.Impulse);
        }
    }
}
