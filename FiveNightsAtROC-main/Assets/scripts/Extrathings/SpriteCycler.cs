using UnityEngine;
using TMPro;

public class SpriteCycler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Assign the SpriteRenderer in the scene
    public Sprite[] sprites;               // Drag your sprites here
    public string[] names;                 // Must match sprites.Length
    [TextArea]
    public string[] descriptions;          // Must match sprites.Length

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Vector2 targetSize = new Vector2(1f, 1f); // Set the desired size of the sprites

    private int currentIndex = 0;

    void Start()
    {
        if (sprites.Length > 0)
            SetPerson(0);
    }

    public void NextSprite()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex + 1) % sprites.Length;
        SetPerson(currentIndex);
    }

    public void PreviousSprite()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        SetPerson(currentIndex);
    }

    private void SetPerson(int index)
    {
        // Update sprite
        spriteRenderer.sprite = sprites[index];

        // Resize sprite to target size
        if (spriteRenderer.sprite != null)
        {
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            spriteRenderer.transform.localScale = new Vector3(
                targetSize.x / spriteSize.x,
                targetSize.y / spriteSize.y,
                1f
            );
        }

        // Update name and description
        if (nameText != null) nameText.text = names[index];
        if (descriptionText != null) descriptionText.text = descriptions[index];
    }
}
