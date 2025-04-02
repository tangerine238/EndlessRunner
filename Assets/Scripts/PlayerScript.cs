using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScript : MonoBehaviour
{

    float score;

    bool isAlive = true;

    Rigidbody2D RB;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI FinalScore;
    public static PlayerScript Instance { get; private set; }

    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Instance = this;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = "Score : " + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            ShowGameOver();
            isAlive = false;
            Time.timeScale = 0;
        }
    }

    public float GetScore()
    {
        return score;
    }

    private void ShowGameOver()
    {
        FinalScore.text = "Final Score: " + score.ToString("F");
        gameOverScreen.SetActive(true);
    }


}
