using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshProUGUI scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player != null)
            player.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        if (player != null)
            player.OnScoreChanged -= UpdateScore;
    }
}
