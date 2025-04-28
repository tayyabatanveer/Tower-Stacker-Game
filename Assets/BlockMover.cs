using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float swayAmount = 0.3f;
    public float swaySpeed = 1f;

    private Vector3 startPosition;
    private Rigidbody rb;
    private bool isFirstBlock = false;  // Flag for first block

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        //flag is true if its first block
        if (transform.position.y == 1)//placed
        {
            isFirstBlock = true;
        }
    }

    void Update()
    {
        //the physics sway movements
        float xMovement = Mathf.Sin(Time.time * moveSpeed) * 2f;
        transform.position = startPosition + new Vector3(xMovement, 0, 0);

        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        rb.AddForce(new Vector3(sway, 0, 0), ForceMode.VelocityChange);
    }

    // Detect collision with the ground
    void OnCollisionEnter(Collision collision)
    {
        if (!isFirstBlock)  // Only check for collision if it's not the first block
        {
            if (collision.gameObject.CompareTag("Ground"))  
            {
                FindObjectOfType<GameManager>().GameOver();  //Call GameOver if this block hits the ground
            }
        }
    }
}
