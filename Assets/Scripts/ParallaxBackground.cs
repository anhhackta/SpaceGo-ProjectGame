using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.6f;
    [SerializeField] private float tileWidth = 20f;

    private Transform _a;
    private Transform _b;

    public void Setup(Transform a, Transform b, float parallaxSpeed, float width)
    {
        _a = a;
        _b = b;
        speed = parallaxSpeed;
        tileWidth = width;
    }

    private void Update()
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver || _a == null || _b == null) return;

        var delta = Vector3.left * gm.ScrollSpeed * speed * Time.deltaTime;
        _a.position += delta;
        _b.position += delta;

        if (_a.position.x < _b.position.x)
        {
            Wrap(_a, _b);
        }
        else
        {
            Wrap(_b, _a);
        }
    }

    private void Wrap(Transform left, Transform right)
    {
        if (left.position.x <= -tileWidth)
        {
            left.position = new Vector3(right.position.x + tileWidth, left.position.y, left.position.z);
        }
    }
}
