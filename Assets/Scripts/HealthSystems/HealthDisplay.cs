using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Slider healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player != null)
            player.OnHealthChanged += UpdateHealthBar;
    }


    private void UpdateHealthBar(float current, float max)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = max;
            healthBar.value = current;
        }
    }

    private void OnDestroy()
    {
        if (player != null)
            player.OnHealthChanged -= UpdateHealthBar;
    }
}
