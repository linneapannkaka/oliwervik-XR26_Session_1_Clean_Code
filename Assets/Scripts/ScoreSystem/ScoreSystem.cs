using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public event Action OnPlayerWon;

    private int currentScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player != null)
            player.OnScoreChanged += HandleScoreChanged;
    }

    private void HandleScoreChanged (int newScore)
    {
        currentScore = newScore;

        if (currentScore >= 30)
        {
            Debug.Log("ScoreSystem: Player won!");
            OnPlayerWon?.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (player != null)
            player.OnScoreChanged -= HandleScoreChanged;
    }
}
