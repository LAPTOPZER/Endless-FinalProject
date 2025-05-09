using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private float destroyXPos = -10f;

    void Update()
    {
        if (transform.position.x < destroyXPos)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
