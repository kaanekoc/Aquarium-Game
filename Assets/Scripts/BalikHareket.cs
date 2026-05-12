using UnityEngine;

public class BalikHareket : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeInterval = 2f;

    public Vector2 minBounds = new Vector2(-9f, -5f);
    public Vector2 maxBounds = new Vector2(9f, 5f);

    public Sprite rightSprite; // sağa bakan sprite
    public Sprite leftSprite;  // sola bakan sprite

    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private GameObject hedefYem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(ChangeDirection), 0f, directionChangeInterval);
    }
    void Update()
    {
        GameObject hedefYem = GameObject.FindWithTag("Yem");
        if (hedefYem != null)
        {
            Vector2 direction = (hedefYem.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }


    void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * moveSpeed;

        // Sınır kontrolü
        Vector2 newPos = transform.position;

        if (newPos.x < minBounds.x || newPos.x > maxBounds.x)
            movementDirection.x *= -1;

        if (newPos.y < minBounds.y || newPos.y > maxBounds.y)
            movementDirection.y *= -1;

        // Yönüne göre sprite değiştir
        if (movementDirection.x > 0.01f)
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (movementDirection.x < -0.01f)
        {
            spriteRenderer.sprite = leftSprite;
        }
    }

    void ChangeDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        movementDirection = new Vector2(x, y).normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Yem"))
        {
            Destroy(other.gameObject);
            hedefYem = null;

            // Rastgele hareket için tekrar yön değişimini başlat
            CancelInvoke(nameof(ChangeDirection)); // önce eskiyi iptal et
            InvokeRepeating(nameof(ChangeDirection), 0f, directionChangeInterval);

            Debug.Log("Balık yemi yedi!");
        }
    }
}
