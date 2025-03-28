using UnityEngine;
using UnityEngine.UI; // Only if using a UI-based RawImage

[ExecuteAlways]
public class ArrowDrawer : MonoBehaviour
{
    public int textureSize = 256; // Size of the canvas (square)
    public Color arrowColor = Color.white; // Color of the arrow


    private Texture2D texture;
    private SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        Start();
    }

    void Start()
    {
        // Create a blank texture
        texture = new Texture2D(textureSize, textureSize);
        texture.filterMode = FilterMode.Point;
        ClearTexture();

        // Assign to a SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, textureSize, textureSize), new Vector2(0.5f, 0.5f));
            spriteRenderer.sprite = sprite;
        }
    }

    public void Draw(Vector3 startPos, Vector3 endPos)
    {
        ClearTexture(); // Clear previous frame

        // Get the arrow direction
        Vector3 direction = endPos - startPos;

        // Convert direction to texture space
        Vector2 start = new Vector2(textureSize / 2, textureSize / 2);
        Vector2 end = start + new Vector2(direction.x, direction.y) * (textureSize / 2);

        // Draw the arrow
        DrawLine((int)start.x, (int)start.y, (int)end.x, (int)end.y, arrowColor);
        // Apply changes to texture
        texture.Apply();
    }

    void DrawLine(int x0, int y0, int x1, int y1, Color color)
    {
        int dx = Mathf.Abs(x1 - x0);
        int dy = Mathf.Abs(y1 - y0);
        int sx = (x0 < x1) ? 1 : -1;
        int sy = (y0 < y1) ? 1 : -1;
        int err = dx - dy;

        while (true)
        {
            texture.SetPixel(x0, y0, color);
            if (x0 == x1 && y0 == y1) break;
            int e2 = 2 * err;
            if (e2 > -dy) { err -= dy; x0 += sx; }
            if (e2 < dx) { err += dx; y0 += sy; }
        }
    }

    void ClearTexture()
    {
        for (int x = 0; x < textureSize; x++)
        {
            for (int y = 0; y < textureSize; y++)
            {
                texture.SetPixel(x, y, Color.clear);
            }
        }
    }
}
