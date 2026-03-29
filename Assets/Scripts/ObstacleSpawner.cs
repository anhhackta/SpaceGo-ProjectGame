using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Area")]
    public float spawnX = 11f;
    public float minY = -4.2f;
    public float maxY = 4.2f;

    [Header("Pacing")]
    public float baseSpawnInterval = 1.1f;
    [Range(0f, 1f)] public float enemyChance = 0.24f;

    private float _timer;

    private void Update()
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver) return;

        if (MobileViewport.SpawnX != 0f)
        {
            spawnX = MobileViewport.SpawnX;
            minY = MobileViewport.PlayBottom;
            maxY = MobileViewport.PlayTop;
        }

        _timer -= Time.deltaTime;
        if (_timer > 0f) return;

        SpawnOne(gm.DifficultyLevel);

        var interval = Mathf.Max(0.35f, baseSpawnInterval - gm.DifficultyLevel * 0.08f);
        _timer = interval;
    }

    private void SpawnOne(int level)
    {
        if (Random.value < enemyChance + level * 0.01f)
        {
            SpawnEnemy();
        }
        else
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        var content = SpaceGoContentLibrary.Instance;
        var position = new Vector3(spawnX, Random.Range(minY, maxY), 0f);

        var obstacle = SpaceGoContentLibrary.SpawnFromTemplate(
            content != null ? content.asteroidTemplate : null,
            "Asteroid",
            position);

        if (obstacle == null)
        {
            obstacle = new GameObject("Asteroid");
            obstacle.transform.position = position;
        }

        var size = Random.Range(0.8f, 1.9f);
        SpaceGoContentLibrary.ApplyVisual(
            obstacle,
            content != null ? content.asteroidSprite : null,
            new Color(0.62f, 0.58f, 0.68f),
            new Vector2(size, size),
            8);

        var col = obstacle.GetComponent<BoxCollider2D>();
        if (col == null) col = obstacle.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        var obstacleData = obstacle.GetComponent<Obstacle>();
        if (obstacleData == null) obstacleData = obstacle.AddComponent<Obstacle>();
        obstacleData.coinReward = 1;

        if (obstacle.GetComponent<ScrollMover>() == null)
        {
            obstacle.AddComponent<ScrollMover>();
        }
    }

    private void SpawnEnemy()
    {
        var content = SpaceGoContentLibrary.Instance;
        var position = new Vector3(spawnX, Random.Range(minY + 0.5f, maxY - 0.5f), 0f);

        var enemy = SpaceGoContentLibrary.SpawnFromTemplate(
            content != null ? content.enemyTemplate : null,
            "EnemyShip",
            position);

        if (enemy == null)
        {
            enemy = new GameObject("EnemyShip");
            enemy.transform.position = position;
        }

        SpaceGoContentLibrary.ApplyVisual(
            enemy,
            content != null ? content.enemyShipSprite : null,
            new Color(1f, 0.4f, 0.4f),
            new Vector2(1.25f, 0.8f),
            9);

        var col = enemy.GetComponent<BoxCollider2D>();
        if (col == null) col = enemy.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        if (enemy.GetComponent<ScrollMover>() == null)
        {
            enemy.AddComponent<ScrollMover>();
        }

        if (enemy.GetComponent<EnemyShip>() == null)
        {
            enemy.AddComponent<EnemyShip>();
        }
    }
}
