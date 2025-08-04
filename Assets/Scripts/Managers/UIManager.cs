using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elemets")]
    [SerializeField] private TextMeshProUGUI gameStatusText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gameResultText;
    [SerializeField] private GameObject gameOverPanel;

    // Generel clean kod, men lägg till Debug log ifall något av nedanstående element = null

    public void SetTimer(float time)
    {
        if (timerText != null)
            timerText.text = $"Time; {Mathf.FloorToInt(time)}s";
    }

    public void ShowStatus(string message)
    {
        if (gameStatusText != null)
            gameStatusText.text = message;
    }

    public void GameResult(string message)
    {
        if (gameResultText != null)
            gameResultText.text = message;
    }

    public void ShowGameOverPanel(bool show)
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(show);
    }
}
