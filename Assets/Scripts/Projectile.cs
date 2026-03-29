using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 14f;
    public bool fromPlayer = true;

    private void Update()
    {
        if (SpaceGoGameManager.Instance != null && SpaceGoGameManager.Instance.IsGameOver)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);

        var left = MobileViewport.Left;
        var right = MobileViewport.Right;
        var bottom = MobileViewport.Bottom;
        var top = MobileViewport.Top;

        if (right != 0f && left != 0f)
        {
            const float pad = 3f;
            if (transform.position.x < left - pad || transform.position.x > right + pad ||
                transform.position.y < bottom - pad || transform.position.y > top + pad)
            {
                Destroy(gameObject);
            }
            return;
        }

        if (Mathf.Abs(transform.position.x) > 25f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver) return;

        if (fromPlayer)
        {
            if (other.TryGetComponent<Obstacle>(out var obstacle))
            {
                gm.AddCoins(obstacle.coinReward);
                gm.AddScore(20f);
                GameAudio.Instance?.PlayExplosion();
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }

            if (other.TryGetComponent<EnemyShip>(out var enemy))
            {
                gm.AddCoins(enemy.coinReward);
                gm.AddScore(40f);
                GameAudio.Instance?.PlayExplosion();
                enemy.Die();
                Destroy(gameObject);
            }

            return;
        }

        if (other.GetComponent<PlayerShipController>() != null)
        {
            GameAudio.Instance?.PlayDeath();
            gm.TriggerGameOver();
            Destroy(gameObject);
        }
    }
}
