using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpVelocity = 6f;
    [SerializeField] private float maxUpwardVelocity = 8f;
    [SerializeField] private float maxDownwardVelocity = -10f;

    [Header("Physics Settings")]
    [SerializeField] private float gravityScale = 2f;


    [SerializeField] private TextMeshProUGUI scoreText;
    private Rigidbody2D rb2d;
    private readonly bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = gravityScale;
    }

    void Update()
    {
        HandleInput();
        ClampVelocity();
    }

    private void HandleInput()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpVelocity);
    }

    private void ClampVelocity()
    {
        float clampedY = Mathf.Clamp(rb2d.linearVelocity.y, maxDownwardVelocity, maxUpwardVelocity);
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, clampedY);
    }


    void LateUpdate()
    {
        if (!isDead)
        {
            float angle = Mathf.Lerp(-30f, 30f, (rb2d.linearVelocity.y + 10f) / 20f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Ground"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (other.CompareTag("Score"))
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
        }
    }
}