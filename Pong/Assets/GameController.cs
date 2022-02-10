using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int leftScore = 0;
    int rightScore = 0;

    public int maxScore = 3;
    bool gameOver = false;

    public Text scoreText;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Score(bool leftPlayerScored)
    {
        if(leftPlayerScored)
            leftScore++;
        else
            rightScore++;

        if(leftScore >= maxScore)
        {
            scoreText.text = "Left Player Wins!";
            GameOver();
        }
        else if (rightScore >= maxScore)
        {
            scoreText.text = "Right Player Wins!";
            GameOver();
        }
        else
            scoreText.text = leftScore + " : " + rightScore;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            if (Input.anyKeyDown)
                Restart();
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
