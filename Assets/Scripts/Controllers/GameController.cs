using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public LevelsData levelsData;

    [SerializeField] private UIController uiController;

    [SerializeField] private Transform downFailPoint;

    [SerializeField] private Transform upFailPoint;

    private List<PlatformMover> platforms = new List<PlatformMover>();

    [SerializeField] private AudioSource audioSource;

    private int score;

    private bool isWin;

    private bool isGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSettings();
    }

    private void StartSettings()
    {
        Time.timeScale = 1;
    }

    public void ScoreChange()
    {
        score++;

        uiController.ChangeScoreText(score);
    }

    public float GetFailPoint(bool isUp)
    {
        if (isUp) return upFailPoint.position.y;
        else return downFailPoint.position.y;
    }

    public void AllLevelsPlatform(bool isAdd ,PlatformMover getPlatforms)
    {
        if (isAdd) platforms.Add(getPlatforms);
        else platforms.Remove(getPlatforms);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Win()
    {
        if (isGameOver) return;

        isWin = true;

        uiController.SelectActivePanel(1);
    }

    public void GameOver()
    {
        if (isWin) return;

        isGameOver = true;

        audioSource.volume = 0;

        foreach (var platform in platforms)
        {
            platform.MoveMode(true);
        }

        uiController.SelectActivePanel(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
