using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0f;
    public float scoreInterval = 0.1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        while (timer >= scoreInterval)
        {
            score += 1;
            timer -= scoreInterval;
        }

        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

    }
}
