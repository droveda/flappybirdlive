using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject gameOverText;

    public GameObject startText;

    public GameObject pauseText;

    public bool gameOver = false;

    public bool gameStarted = false;

    public bool gamePaused = false;

    public float scrollSpeed = -1.5f;

    private int score = 0;

    public Text scoreText;

    // Awake is called before start
    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    void Start()
    {
        //Debug.Log("Start...");
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameStarted && !gameOver) {
            if (!gamePaused) {
                PauseGame();
                gamePaused = true;
                pauseText.SetActive(true);
            } else {
                ResumeGame();
                gamePaused = false;
                pauseText.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            ResumeGame();
            gameStarted = true;
            startText.SetActive(false);
        }

        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();

        SoundManagerScript.PlaySound("scored");
    }

    public void BirdDied() 
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }
}
