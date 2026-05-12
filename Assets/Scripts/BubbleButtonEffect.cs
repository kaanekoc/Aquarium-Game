using UnityEngine;

public class BubbleButtonEffect : MonoBehaviour
{
    public float scaleAmount = 0.05f; // Ne kadar büyüsün/küçülsün
    public float speed = 2f;          // Animasyon hýzý

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scaleOffset = Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = startScale + Vector3.one * scaleOffset;
    }
}
