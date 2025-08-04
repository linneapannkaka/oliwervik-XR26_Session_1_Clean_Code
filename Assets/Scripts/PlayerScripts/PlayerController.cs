using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float rotationSpeed = 0.5f;

    [Header("Stats")]
    [SerializeField] private float maxHealth = 30f;
    private float health;
    private int score;

    private Rigidbody rb;
    private bool isGrounded;
    private float yaw; // Rörelse, t.ex typ en term för rotation av ett slag, som en flygplans-joystick? Kolla vilken

    public event Action<int> OnScoreChanged;
    public event Action<float, float> OnHealthChanged; // Like a megaphone, "I took damage" instead of "HealthBar you better change now"
    public event Action OnPlayerDied;

    [SerializeField] private PlayerInputHandler input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;

        OnHealthChanged?.Invoke(health, maxHealth); // Feedback från Totte, vad gör health och score i detta script om man ska följa SOLID
        OnScoreChanged?.Invoke(score); // Välj vad detta script gör, ett "område" enligt solid
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        yaw += input.MouseX * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Jump
        if (input.JumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Death
        if (health <= 0)
        {
            OnPlayerDied?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = transform.forward * input.Vertical + transform.right * input.Horizontal;
        rb.MovePosition(rb.position + move.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Collectible"))
        {
            score += 10;
            OnScoreChanged?.Invoke(score);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
        }

    }

    public void TakeDamage (float amount)
    {
        health = Mathf.Max(0, health - amount);
        OnHealthChanged?.Invoke(health, maxHealth);
    }

    public int GetScore() => score;
}
