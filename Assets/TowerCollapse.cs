using UnityEngine;
using UnityEngine.SceneManagement;  

public class TowerCollapse : MonoBehaviour
{
    public float collapseAngle = 30f;
    private Transform[] blocks;
    public int score = 0;

    void Start()
    {
        blocks = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        
        if (Vector3.Angle(transform.up, Vector3.up) > collapseAngle)
        {
            CollapseTower();
        }

        // Update score based on the tower height or block count
        score = Mathf.FloorToInt(transform.position.y);
    }

    void CollapseTower()
    {
        Debug.Log("Tower Collapsed!");
        
        foreach (Transform block in blocks)
        {
            Destroy(block.gameObject);
        }

        // Show the final score
        Debug.Log("Game Over! Your Score: " + BlockSpawner.score);


        // Restart the game (reload the scene)
        Invoke(nameof(RestartGame), 2f);  // Wait for 2 seconds before
    }

    void RestartGame()
    {
        BlockSpawner.score = 0;  // Reset score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload current scene
    }
}
