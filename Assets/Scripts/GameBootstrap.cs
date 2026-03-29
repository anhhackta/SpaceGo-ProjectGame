using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameBootstrap : MonoBehaviour
{
    private void Awake()
    {
        SetupCamera();
        EnsureContentLibrary();
        EnsureViewport();
        SetupBackground();

        if (FindFirstObjectByType<SpaceGoGameManager>() == null)
        {
            new GameObject("SpaceGoGameManager").AddComponent<SpaceGoGameManager>();
        }

        if (FindFirstObjectByType<GameAudio>() == null)
        {
            new GameObject("GameAudio").AddComponent<GameAudio>();
        }

        if (FindFirstObjectByType<PlayerShipController>() == null)
        {
            var player = new GameObject("PlayerShip");
            player.AddComponent<Rigidbody2D>();
            player.AddComponent<CircleCollider2D>();
            player.AddComponent<PlayerShipController>();
        }

        if (FindFirstObjectByType<ObstacleSpawner>() == null)
        {
            new GameObject("ObstacleSpawner").AddComponent<ObstacleSpawner>();
        }
    }

    private static void SetupCamera()
    {
        var cam = Camera.main;
        if (cam == null)
        {
            var camGo = new GameObject("Main Camera");
            cam = camGo.AddComponent<Camera>();
            camGo.tag = "MainCamera";
        }

        cam.orthographic = true;
        cam.transform.position = new Vector3(0f, 0f, -10f);
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color(0.03f, 0.04f, 0.1f);

        if (cam.GetComponent<MobileCameraScaler>() == null)
        {
            cam.gameObject.AddComponent<MobileCameraScaler>();
        }
    }

    private static void EnsureContentLibrary()
    {
        if (FindFirstObjectByType<SpaceGoContentLibrary>() == null)
        {
            new GameObject("SpaceGoContentLibrary").AddComponent<SpaceGoContentLibrary>();
        }
    }

    private static void EnsureViewport()
    {
        if (FindFirstObjectByType<MobileViewport>() == null)
        {
            new GameObject("MobileViewport").AddComponent<MobileViewport>();
        }
    }

    private static void SetupBackground()
    {
        if (GameObject.Find("BG_Space_A") != null) return;

        var content = SpaceGoContentLibrary.Instance;

        var layer = new GameObject("BackgroundLayer");

        CreateTiledBackground(
            layer.transform,
            "BG_Space",
            content != null ? content.backgroundSpaceSprite : null,
            new Color(0.08f, 0.1f, 0.2f),
            40f,
            22f,
            -2f,
            0.12f,
            -20);

        CreateTiledBackground(
            layer.transform,
            "BG_Stars",
            content != null ? content.backgroundStarsSprite : null,
            new Color(1f, 1f, 1f, 0.6f),
            40f,
            22f,
            -1f,
            0.28f,
            -10);
    }

    private static void CreateTiledBackground(
        Transform parent,
        string rootName,
        Sprite sprite,
        Color fallback,
        float width,
        float height,
        float z,
        float speed,
        int sortingOrder)
    {
        var root = new GameObject(rootName);
        root.transform.SetParent(parent, false);

        var a = new GameObject($"{rootName}_A");
        var b = new GameObject($"{rootName}_B");
        a.transform.SetParent(root.transform, false);
        b.transform.SetParent(root.transform, false);

        a.transform.position = new Vector3(0f, 0f, z);
        b.transform.position = new Vector3(width, 0f, z);

        SpaceGoContentLibrary.ApplyVisual(a, sprite, fallback, new Vector2(width, height), sortingOrder);
        SpaceGoContentLibrary.ApplyVisual(b, sprite, fallback, new Vector2(width, height), sortingOrder);

        var p = root.AddComponent<ParallaxBackground>();
        p.Setup(a.transform, b.transform, speed, width);
    }
}
