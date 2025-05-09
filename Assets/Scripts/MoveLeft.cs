using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    private float leftBound = -15;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            float moveSpeed;
            if (PlayerController.isSprinting)
            {
                moveSpeed = speed * 2;
            }
            else
            {
                moveSpeed = speed * 1;
            }
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
