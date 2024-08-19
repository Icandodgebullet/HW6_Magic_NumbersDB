using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _playAgain;
    [SerializeField] private Button _exitGame;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _gameOverText.text = $"Поздравляем! Ваше число: {MagicNumbers.Guess}, ходов затрачено: {MagicNumbers.MovesCount}";
        _playAgain.onClick.AddListener(PlayAgain);
        _exitGame.onClick.AddListener(ExitGame);
    }

    #endregion

    #region Private methods

    private void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}