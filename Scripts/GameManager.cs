using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseButton;
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        Pause();
        fadeScreen.SetActive(true);
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
