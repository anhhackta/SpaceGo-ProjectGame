using UnityEngine;

public static class DemoSprite
{
    private static Sprite _square;

    public static Sprite Square
    {
        get
        {
            if (_square != null) return _square;

            var texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();
            _square = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            _square.name = "DemoSquareSprite";
            return _square;
        }
    }

    public static SpriteRenderer Setup(GameObject target, Color color, Vector2 size)
    {
        var renderer = target.GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            renderer = target.AddComponent<SpriteRenderer>();
        }

        renderer.sprite = Square;
        renderer.color = color;
        target.transform.localScale = new Vector3(size.x, size.y, 1f);
        return renderer;
    }
}
