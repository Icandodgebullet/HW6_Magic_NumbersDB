using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _textStart;
    [SerializeField] private TextMeshProUGUI _textGame;
    [SerializeField] private TextMeshProUGUI _textMovesCount;
    [SerializeField] private Button _upperButton;
    [SerializeField] private Button _lowerButton;
    [SerializeField] private Button _guessedRightButton;
    [Header("ETC")]
    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min;
    private int _currentMax;
    private int _currentMin;

    #endregion

    #region Properties

    public static int Guess { get; private set; }

    public static int MovesCount { get; private set; }

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _currentMin = _min;
        _currentMax = _max;
        MovesCount = 1;
        _upperButton.onClick.AddListener(UpperPressed);
        _lowerButton.onClick.AddListener(LowerPressed);
        _guessedRightButton.onClick.AddListener(GuessedRightPressed);

        StartGame();
    }

    private void Update() { }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        Guess = (_max + _min) / 2;
        _textGame.text = $"Ваше число равно {Guess}?";
        _textMovesCount.text = $"Количество ходов {MovesCount}";
    }

    private void GuessedRightPressed()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void LowerPressed()
    {
        MovesCount++;
        _max = Guess;
        CalculateGuessAndLog();
    }

    private void StartGame()
    {
        _textStart.text = $"Загадайте число от {_currentMin} до {_currentMax}";
        _min = _currentMin;
        _max = _currentMax;
        Guess = 0;
        MovesCount = 1;
        CalculateGuessAndLog();
    }

    private void UpperPressed()
    {
        MovesCount++;
        _min = Guess;
        CalculateGuessAndLog();
    }

    #endregion
}