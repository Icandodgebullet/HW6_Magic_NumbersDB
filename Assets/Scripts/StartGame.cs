using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    #endregion

    #region Unity lifecycle

    // Start is called before the first frame update
    private void Start()
    {
        _startButton.onClick.AddListener(StartGameScene);
        _exitButton.onClick.AddListener(ExitGameScene);
    }

    // Update is called once per frame
    private void Update() { }

    #endregion

    #region Private methods

    private void ExitGameScene()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}