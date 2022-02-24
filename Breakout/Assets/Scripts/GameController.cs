using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int lives = 3;
    int numOfBricks;

    [SerializeField]
    private Text LivesText;
    [SerializeField]
    private Text BricksText;

    public GameObject gameOverUI;

    bool gameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        LivesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        BricksText.text = "Bricks: " + numOfBricks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.anyKeyDown)
        {
            Restart();
        }
    }

    public void LoseLive()
    {
        lives--;
        LivesText.text = "Lives: " + lives.ToString();
        if(lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HitBrick()
    {
        numOfBricks--;
        BricksText.text = "Bricks: " + numOfBricks.ToString();
        if(numOfBricks <= 0)
        {
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Scene02");
        Time.timeScale = 1f;
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene01");
    }

}
