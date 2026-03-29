using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerShipController : MonoBehaviour
{
    [Header("Control")]
    public float impulsePower = 7f;
    public float gravityScale = 2.7f;

    [Header("Shooting")]
    public float shootCooldown = 0.12f;
    public float bulletSpeed = 16f;

    private Rigidbody2D _rb;
    private float _nextShootTime;

    private void Awake()
    {
        var content = SpaceGoContentLibrary.Instance;

        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = gravityScale;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        var col = GetComponent<CircleCollider2D>();
        col.isTrigger = false;
        col.radius = 0.45f;

        SpaceGoContentLibrary.ApplyVisual(
            gameObject,
            content != null ? content.playerShipSprite : null,
            new Color(0.3f, 0.85f, 1f),
            new Vector2(1.1f, 0.65f),
            10);
        transform.position = new Vector3(-6f, 0f, 0f);
    }

    private void Update()
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver) return;

        var top = MobileViewport.PlayTop != 0f ? MobileViewport.PlayTop : 5.8f;
        var bottom = MobileViewport.PlayBottom != 0f ? MobileViewport.PlayBottom : -5.8f;
        if (transform.position.y > top || transform.position.y < bottom)
        {
            gm.TriggerGameOver();
            return;
        }

        if (!PressedThisFrame(out var worldPoint)) return;

        var direction = worldPoint.y > transform.position.y ? Vector2.down : Vector2.up;
        _rb.AddForce(direction * impulsePower, ForceMode2D.Impulse);

        if (Time.time >= _nextShootTime)
        {
            Shoot();
            GameAudio.Instance?.PlayShoot();
            _nextShootTime = Time.time + shootCooldown;
        }
    }

    private bool PressedThisFrame(out Vector3 worldPoint)
    {
        worldPoint = default;

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began) return false;
            worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
            return true;
        }

        if (!Input.GetMouseButtonDown(0)) return false;
        worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return true;
    }

    private void Shoot()
    {
        var content = SpaceGoContentLibrary.Instance;
        var spawnPos = transform.position + new Vector3(0.9f, 0f, 0f);

        var bullet = SpaceGoContentLibrary.SpawnFromTemplate(
            content != null ? content.playerBulletTemplate : null,
            "PlayerBullet",
            spawnPos);

        if (bullet == null)
        {
            bullet = new GameObject("PlayerBullet");
            bullet.transform.position = spawnPos;
        }

        SpaceGoContentLibrary.ApplyVisual(
            bullet,
            content != null ? content.playerBulletSprite : null,
            Color.yellow,
            new Vector2(0.35f, 0.16f),
            12);

        var col = bullet.GetComponent<CircleCollider2D>();
        if (col == null) col = bullet.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        var rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null) rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.isKinematic = true;

        var projectile = bullet.GetComponent<Projectile>();
        if (projectile == null) projectile = bullet.AddComponent<Projectile>();
        projectile.fromPlayer = true;
        projectile.direction = Vector2.right;
        projectile.speed = bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SpaceGoGameManager.Instance == null) return;

        if (collision.gameObject.GetComponent<Obstacle>() != null || collision.gameObject.GetComponent<EnemyShip>() != null)
        {
            GameAudio.Instance?.PlayDeath();
            SpaceGoGameManager.Instance.TriggerGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SpaceGoGameManager.Instance == null) return;

        if (other.GetComponent<EnemyShip>() != null || other.GetComponent<Obstacle>() != null)
        {
            GameAudio.Instance?.PlayDeath();
            SpaceGoGameManager.Instance.TriggerGameOver();
        }
    }
}
