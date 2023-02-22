using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI ScoreText;
    public int Score = 0;
    public int ActivePlayers = 0;
    public bool isAttack;
    public bool IsPlayerImmortal = true;
    public bool IsGameStart = false;
    public TextMeshProUGUI FinalBossText;
    public int FinalBossScore = 100;
    public bool CameraNewPosition = false;
    public GameObject StartCanvas;
    public GameObject WinCanvas;
    public GameObject RestartCanvas;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ScoreText.text = ActivePlayers.ToString();
    }


    public int ScoreCounter(int s)
    {
        Score += s;
        ScoreText.text = s.ToString();

        return s;
    }

    public void DecreaseTheFinalBossScore()
    {
        FinalBossScore--;
        FinalBossText.text = FinalBossScore.ToString();
    }

    public void StartTheGame()
    {
        IsGameStart = true;
        StartCanvas.SetActive(false);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgainButton()
    {
        CameraNewPosition = true;
        SceneManager.LoadScene(0);
    }
}
