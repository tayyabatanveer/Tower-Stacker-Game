using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnOffset = 2f;
    private GameObject currentBlock;
    private Transform lastBlock;
    [SerializeField] private Transform towerParent;
    public static int score = 0;

    void Start()
    {
        SpawnNewBlock();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && currentBlock != null)
        {
            // Drop current block
            Rigidbody rb = currentBlock.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            currentBlock.GetComponent<BlockMover>().enabled = false;

            lastBlock = currentBlock.transform;
            currentBlock = null;
            score++;  // Increase score when a new block is added
            GameManager.Instance.UpdateScore(score);
            Debug.Log("Score: " + score);  // Display score in the console

            Invoke(nameof(SpawnNewBlock), 0.5f);//delay
        }
    }

    void SpawnNewBlock()
    {
        Vector3 spawnPosition = (lastBlock != null)
            ? lastBlock.position + Vector3.up * spawnOffset
            : new Vector3(0, 1, 0);

        currentBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

        // Attach to tower parent
        currentBlock.transform.parent = towerParent;

        // Random size
        float randomScale = Random.Range(1.5f, 3f);
        currentBlock.transform.localScale = new Vector3(randomScale, 0.5f, randomScale);

        // Random color
        currentBlock.GetComponent<Renderer>().material.color = new Color(
            Random.value, Random.value, Random.value);

        // Rigidbody setup
        Rigidbody rb = currentBlock.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        // Enable movement
        currentBlock.GetComponent<BlockMover>().enabled = true;
    }
}
