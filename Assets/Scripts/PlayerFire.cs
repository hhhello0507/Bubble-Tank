using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFire : MonoBehaviour
{
    private const float ThrowPower = 30f;
    private const float FireIntervalTime = 0.3f;

    private static readonly Vector3 BubbleOffset = new(0f, 1f, 0f);

    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private GameObject gunBarrel;

    private float fireTime = 0f;

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Running) return;

        fireTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && fireTime >= FireIntervalTime)
        {
            fireTime = 0f;
            
            var bubble = Instantiate(bubblePrefab, transform.position + BubbleOffset, Quaternion.identity);

            var rigidBody = bubble.GetComponent<Rigidbody>();
            rigidBody.AddForce(gunBarrel.transform.forward * ThrowPower, ForceMode.Impulse);
        }
    }
}