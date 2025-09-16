using UnityEngine;
using TMPro;

public class textgoup : MonoBehaviour
{
    public float speed = 50f;             // how fast it moves upward
    public float maxDistance = 200f;      // how far it should move before stopping

    private RectTransform rectTransform;
    private Vector2 startPos;
    private bool moving = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (moving)
        {
            rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            // check how far it's moved
            float distance = Vector2.Distance(startPos, rectTransform.anchoredPosition);
            if (distance >= maxDistance)
            {
                moving = false; // stop moving once max distance reached
            }
        }
    }
}
