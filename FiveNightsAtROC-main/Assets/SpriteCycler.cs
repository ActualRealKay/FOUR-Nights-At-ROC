using UnityEngine;

public class SpriteCycler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public Vector2 targetSize = new Vector2(1f, 1f); // The uniform size you want

    private int currentIndex = 0;

    void Start()
    {
        if (sprites.Length > 0)
            SetSprite(0);
    }

    public void NextSprite()
    {
        if (sprites.Length == 0) return;
        currentIndex++;
        if (currentIndex >= sprites.Length) currentIndex = 0;
        SetSprite(currentIndex);
    }

    public void PreviousSprite()
    {
        if (sprites.Length == 0) return;
        currentIndex--;
        if (currentIndex < 0) currentIndex = sprites.Length - 1;
        SetSprite(currentIndex);
    }

    private void SetSprite(int index)
    {
        spriteRenderer.sprite = sprites[index];

        // Resize to target size
        if (spriteRenderer.sprite != null)
        {
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            spriteRenderer.transform.localScale = new Vector3(
                targetSize.x / spriteSize.x,
                targetSize.y / spriteSize.y,
                1f
            );
        }
    }
}
