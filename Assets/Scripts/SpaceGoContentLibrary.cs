using UnityEngine;

public class SpaceGoContentLibrary : MonoBehaviour
{
    public static SpaceGoContentLibrary Instance { get; private set; }

    [Header("Optional sprites (drag in Inspector)")]
    public Sprite playerShipSprite;
    public Sprite enemyShipSprite;
    public Sprite asteroidSprite;
    public Sprite playerBulletSprite;
    public Sprite enemyBulletSprite;
    public Sprite backgroundSpaceSprite;
    public Sprite backgroundStarsSprite;

    [Header("Optional scene templates (inactive objects)")]
    public GameObject asteroidTemplate;
    public GameObject enemyTemplate;
    public GameObject playerBulletTemplate;
    public GameObject enemyBulletTemplate;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        AutoBindTemplates();
    }

    private void OnValidate()
    {
        AutoBindTemplates();
    }

    private void AutoBindTemplates()
    {
        if (asteroidTemplate == null)
        {
            var go = FindSceneObjectByName("TPL_Asteroid");
            if (go != null) asteroidTemplate = go;
        }

        if (enemyTemplate == null)
        {
            var go = FindSceneObjectByName("TPL_EnemyShip");
            if (go != null) enemyTemplate = go;
        }

        if (playerBulletTemplate == null)
        {
            var go = FindSceneObjectByName("TPL_PlayerBullet");
            if (go != null) playerBulletTemplate = go;
        }

        if (enemyBulletTemplate == null)
        {
            var go = FindSceneObjectByName("TPL_EnemyBullet");
            if (go != null) enemyBulletTemplate = go;
        }
    }

    private static GameObject FindSceneObjectByName(string objectName)
    {
        var transforms = FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var t in transforms)
        {
            if (t == null || !t.gameObject.scene.IsValid()) continue;
            if (t.name == objectName) return t.gameObject;
        }

        return null;
    }

    public static SpriteRenderer ApplyVisual(GameObject target, Sprite sprite, Color fallbackColor, Vector2 size, int sortingOrder)
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

    public static GameObject SpawnFromTemplate(GameObject template, string runtimeName, Vector3 position)
    {
        if (template == null) return null;

        var clone = Instantiate(template, position, Quaternion.identity);
        clone.name = runtimeName;
        clone.SetActive(true);
        return clone;
    }
}
