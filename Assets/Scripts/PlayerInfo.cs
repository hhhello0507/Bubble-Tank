using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    private const int MaxHp = 100;
    private int _hp = MaxHp;
    public int Hp
    {
        get => _hp;
        set
        {
            // GameOver
            if (value < 0)
            {
                GameManager.Instance.GameState = GameState.GameOver;
                return;
            }
            _hp = value;
            SetHpSlider();
        }
    }

    private void Start()
    {
        SetHpSlider();
    }

    private void SetHpSlider()
    {
        hpSlider.value = _hp / (float)MaxHp;
    }
}