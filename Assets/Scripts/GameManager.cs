using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private int _score;
    public Player player;
    public Text ScoreText;
    public GameObject PlayButton;
    public GameObject Gameover;
    public GameObject ExitButton;

    private void Awake()
    {
        Gameover.SetActive(false);
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        _score = 0;
        ScoreText.text = _score.ToString();

        Gameover.SetActive(false);
        PlayButton.SetActive(false);
        ExitButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i<pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Exit()
    {
       Application.Quit();
    }

    public void Pause()
    { 
        ExitButton.SetActive(true);
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        Gameover.SetActive(true);
        PlayButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreText.text = _score.ToString();
    }
}