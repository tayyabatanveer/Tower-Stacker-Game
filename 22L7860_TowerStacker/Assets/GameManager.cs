using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton instance

    public GameObject gameOverPanel;  
    public TextMeshProUGUI scoreText;  
    private int score;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); //for duplicates
        }
    }

    
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        score = BlockSpawner.score;
        scoreText.text = "Score: " + score;
        Time.timeScale = 0f;
        Invoke("RestartGame", 2f);
    }

    // Restart the game by reloading the current scene
    public void RestartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }
    //to be called from other scripts
    public void UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = "Score: " + score.ToString();
    }
}
