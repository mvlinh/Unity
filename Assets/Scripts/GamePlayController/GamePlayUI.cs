using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    private static GamePlayUI instance;
    public static GamePlayUI Instance => instance;
    public Text Text;
    private int colletableCount = 0;
    public AirScript Air { get => air;}

    [SerializeField] GameObject pausePanel;
    [SerializeField] Button resumeGame;
    [SerializeField] AirScript air;

    private void Awake()
    {
        instance = this;
        SetText();
    }
    public void SetText()
    {
        this.Text.text = colletableCount.ToString();
        Debug.Log(colletableCount);
        colletableCount++;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)Scene.Level);

    }

    public void ReStartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayerDied()
    {
        if (GameController.Instance.hack)
        {
            return;
        }
        Time.timeScale = 1f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ReStartGame());
    }
}
