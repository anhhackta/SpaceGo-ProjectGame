using UnityEngine;

public class ScrollMover : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float destroyAtX = -13f;

    private void Update()
    {
        var gm = SpaceGoGameManager.Instance;
        if (gm == null || gm.IsGameOver) return;

        if (MobileViewport.DespawnX != 0f)
        {
            destroyAtX = MobileViewport.DespawnX;
        }

        transform.position += Vector3.left * gm.ScrollSpeed * speedMultiplier * Time.deltaTime;

        if (transform.position.x < destroyAtX)
        {
            Destroy(gameObject);
        }
    }
}
