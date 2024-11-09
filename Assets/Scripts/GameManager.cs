using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
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

    private void Start()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = $"Score : {_score}";
    }
}
