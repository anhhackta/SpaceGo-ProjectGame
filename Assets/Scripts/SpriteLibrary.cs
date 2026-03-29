using UnityEngine;

public static class SpriteLibrary
{
    public static readonly Sprite PlayerShip = Load("player_ship");
    public static readonly Sprite EnemyShip = Load("enemy_ship");
    public static readonly Sprite Asteroid = Load("asteroid");
    public static readonly Sprite PlayerBullet = Load("player_bullet");
    public static readonly Sprite EnemyBullet = Load("enemy_bullet");
    public static readonly Sprite BackgroundSpace = Load("background_space");
    public static readonly Sprite BackgroundStars = Load("background_stars");

    private static Sprite Load(string spriteName)
    {
        return Resources.Load<Sprite>($"Sprites/{spriteName}");
    }

    public static SpriteRenderer Apply(
        GameObject target,
        Sprite sprite,
        Color fallbackColor,
        Vector2 size,
        int sortingOrder = 0)
    {
        var renderer = target.GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            renderer = target.AddComponent<SpriteRenderer>();
        }

        if (sprite != null)
        {
            renderer.sprite = sprite;
            renderer.color = Color.white;

            var bounds = sprite.bounds.size;
            if (bounds.x > 0.0001f && bounds.y > 0.0001f)
            {
                target.transform.localScale = new Vector3(size.x / bounds.x, size.y / bounds.y, 1f);
            }
            else
            {
                target.transform.localScale = new Vector3(size.x, size.y, 1f);
            }
        }
        else
        {
            renderer.sprite = DemoSprite.Square;
            renderer.color = fallbackColor;
            target.transform.localScale = new Vector3(size.x, size.y, 1f);
        }

        renderer.sortingOrder = sortingOrder;
        return renderer;
    }
}
