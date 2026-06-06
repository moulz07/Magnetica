using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;
    public GameObject winUI;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScene"); // menu scene name
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); // your game scene name
        Debug.Log("Button Clicked!");
    }
}