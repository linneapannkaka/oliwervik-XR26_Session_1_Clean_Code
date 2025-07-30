using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private UIManager ui;


    private bool isGameOver = false;
    private float gameTime;

    private void Start()
    {
        ui.ShowStatus("Game Started!");
        ui.ShowGameOverPanel(false);

        player.OnScoreChanged += HandleScore;
        player.OnHealthChanged += HandleHealth;
        player.OnPlayerDied += GameOver;
    }

    private void Update()
    {
        if (isGameOver) return;

        gameTime += Time.deltaTime;
        ui.SetTimer(gameTime);

        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    void HandleScore (int score)
    {
        ui.SetScore(score);
        if (score >= 30)
            WinGame();
    }

    void HandleHealth(float current, float max)
    {
        ui.SetHealth(current, max);
    }

    public void GameOver()
    {
        isGameOver = true;
        ui.GameResult("GAME OVER!");
        ui.ShowGameOverPanel(true);
        Invoke(nameof(RestartGame), 2f);
    }

    void WinGame()
    {
        isGameOver = true;
        ui.GameResult("YOU WIN!");
        ui.ShowGameOverPanel(true);
        Invoke(nameof(RestartGame), 2f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}