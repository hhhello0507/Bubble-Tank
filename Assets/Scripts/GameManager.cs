using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Running,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Button restartButton;
    [SerializeField] private Text bestScoreText;
    
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            if (value < 0) return;
            _score = value;
            SetScoreText();
        }
    }
    private GameState _gameState = GameState.Running;
    public GameState GameState
    {
        get => _gameState;
        set
        {
            switch (value)
            {
                case GameState.Running:
                    break;
                case GameState.GameOver:
                    Time.timeScale = 0f;
                    gameOver.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    
                    var bestScore = PlayerPrefs.GetInt("Score", 0);
                    if (_score > bestScore)
                    {
                        PlayerPrefs.SetInt("Score", _score);
                        bestScore = _score;
                    }
                    bestScoreText.text = $"Best Score : {bestScore}";
                    break;
            }
            _gameState = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        SetScoreText();
        restartButton.onClick.AddListener(() =>
        {
            Debug.Log("Restart game");
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameScene");
        });
    }

    private void SetScoreText()
    {
        scoreText.text = $"Score : {_score}";
    }
}
