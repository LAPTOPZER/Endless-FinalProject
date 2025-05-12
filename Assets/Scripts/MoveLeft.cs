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
            SpeedUp();

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

    //Final Project
    private void SpeedUp()
    {
        if (PlayerController.score >= 2000)
        {
            speed = 18f;
        }
        else if (PlayerController.score >= 1500)
        {
            speed = 15f;
        }
        else if (PlayerController.score >= 500)
        {
            speed = 12f;
        }
    }
}
