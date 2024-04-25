using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private int score;
    private int bestScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Spawner spawner;
    
    private void Awake()
    {
        score = 0;
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        Pause();
    }
    public void Play()
    {
        //Reset values
        score = 0;
        Pipes.Speed = 5f;
        player.Gravity = -9.8f;
        player.Strength = 4;
        spawner.spawnRate = 1f;

        scoreText.text = "Score: " + score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1.0f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>(); 
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        //Debug.Log(score);
    }
    public void GameOver() {
        //Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }
}
