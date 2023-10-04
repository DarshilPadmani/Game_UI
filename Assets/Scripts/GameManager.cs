using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int points=0;
    public Text scoreText;
    public GameObject PauseMenu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = points.ToString();
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateScore(int score)
    {
        points += score;
        scoreText.text = points.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
