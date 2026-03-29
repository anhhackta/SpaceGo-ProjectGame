using UnityEngine;

public class MobileViewport : MonoBehaviour
{
    public static float Left { get; private set; }
    public static float Right { get; private set; }
    public static float Top { get; private set; }
    public static float Bottom { get; private set; }

    [Header("Gameplay margins")]
    public float verticalMargin = 0.8f;
    public float horizontalSpawnPadding = 2f;

    public static float PlayTop { get; private set; }
    public static float PlayBottom { get; private set; }
    public static float SpawnX { get; private set; }
    public static float DespawnX { get; private set; }

    private Camera _cam;
    private int _lastW;
    private int _lastH;

    private void Awake()
    {
        _cam = Camera.main;
        Recalculate();
    }

    private void Update()
    {
        if (_lastW != Screen.width || _lastH != Screen.height)
        {
            Recalculate();
        }
    }

    private void Recalculate()
    {
        if (_cam == null)
        {
            _cam = Camera.main;
            if (_cam == null) return;
        }

        var bl = _cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        var tr = _cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        Left = bl.x;
        Right = tr.x;
        Bottom = bl.y;
        Top = tr.y;

        PlayTop = Top - verticalMargin;
        PlayBottom = Bottom + verticalMargin;

        SpawnX = Right + horizontalSpawnPadding;
        DespawnX = Left - horizontalSpawnPadding;

        _lastW = Screen.width;
        _lastH = Screen.height;
    }
}
