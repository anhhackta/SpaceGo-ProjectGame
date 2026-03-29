using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int coinReward = 3;
    public float fireInterval = 1.8f;
    public float bulletSpeed = 8f;

    private float _timer;

    private void Start()
    {
        _timer = Random.Range(0.25f, 1.2f);
    }

    private void Update()
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver) return;

        _timer -= Time.deltaTime;
        if (_timer > 0f) return;

        Shoot();
        _timer = Mathf.Max(0.65f, fireInterval - gm.DifficultyLevel * 0.08f) + Random.Range(0f, 0.35f);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Shoot()
    {
        var content = SpaceGoContentLibrary.Instance;
        var spawnPos = transform.position + new Vector3(-0.7f, 0f, 0f);

        var bullet = SpaceGoContentLibrary.SpawnFromTemplate(
            content != null ? content.enemyBulletTemplate : null,
            "EnemyBullet",
            spawnPos);

        if (bullet == null)
        {
            bullet = new GameObject("EnemyBullet");
            bullet.transform.position = spawnPos;
        }

        SpaceGoContentLibrary.ApplyVisual(
            bullet,
            content != null ? content.enemyBulletSprite : null,
            new Color(1f, 0.4f, 0.9f),
            new Vector2(0.28f, 0.18f),
            11);

        var col = bullet.GetComponent<CircleCollider2D>();
        if (col == null) col = bullet.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        var rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null) rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.isKinematic = true;

        var projectile = bullet.GetComponent<Projectile>();
        if (projectile == null) projectile = bullet.AddComponent<Projectile>();
        projectile.fromPlayer = false;
        projectile.speed = bulletSpeed;

        var player = FindFirstObjectByType<PlayerShipController>();
        if (player != null)
        {
            var dir = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
            projectile.direction = dir;
        }
        else
        {
            projectile.direction = Vector2.left;
        }

        GameAudio.Instance?.PlayEnemyShoot();
    }
}
