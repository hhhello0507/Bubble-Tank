using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private const float ThrowPower = 30f;
    private const float FireIntervalTime = 0.3f;

    private static readonly Vector3 BubbleOffset = new(0f, 1f, 0f);

    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private GameObject gunBarrel;

    private float _fireTime = 0f;
    private LineRenderer _lineRenderer;
    public int resolution = 30; // 궤적의 세밀도

    private void Start()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.positionCount = resolution;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.startColor = Color.red;
        _lineRenderer.endColor = Color.cyan;
    }

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Running) return;

        _fireTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _fireTime >= FireIntervalTime)
        {
            _fireTime = 0f;

            var bubble = Instantiate(bubblePrefab, transform.position + BubbleOffset, Quaternion.identity);

            var rigidBody = bubble.GetComponent<Rigidbody>();
            rigidBody.AddForce(gunBarrel.transform.forward * ThrowPower, ForceMode.Impulse);
        }
        
        DrawTrajectory();
    }

    private void DrawTrajectory()
    {
        // 궤적 포인트 계산
        var points = new Vector3[resolution];
        var startPosition = transform.position + BubbleOffset;
        var initialVelocity = gunBarrel.transform.forward * ThrowPower;

        for (var i = 0; i < resolution; i++)
        {
            var time = i * (2f * ThrowPower / Mathf.Abs(Physics.gravity.y)) / resolution; // 시간 간격 계산
            points[i] = startPosition +
                        initialVelocity * time +
                        0.5f * time * time * Physics.gravity; // 물리 법칙 기반 포물선
        }

        _lineRenderer.SetPositions(points); // 궤적 설정
    }
}