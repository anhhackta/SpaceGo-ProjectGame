using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceGoGameManager : MonoBehaviour
{
    public static SpaceGoGameManager Instance { get; private set; }

    [Header("Difficulty")]
    public float baseScrollSpeed = 4f;
    public float speedIncreaseEveryPoints = 250f;
    public float speedStep = 0.55f;

    private float _score;
    private int _coins;

    public bool IsGameOver { get; private set; }
    public int Score => Mathf.FloorToInt(_score);
    public int Coins => _coins;
    public int DifficultyLevel => Mathf.FloorToInt(_score / speedIncreaseEveryPoints);
    public float ScrollSpeed => baseScrollSpeed + (DifficultyLevel * speedStep);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (IsGameOver) return;

        _score += Time.deltaTime * (10f + DifficultyLevel * 2.2f);
    }

    public void AddCoins(int amount)
    {
        _coins += Mathf.Max(0, amount);
    }

    public void AddScore(float amount)
    {
        _score += Mathf.Max(0f, amount);
    }

    public void TriggerGameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;
    }

    public void RestartRun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnGUI()
    {
        const int fontSize = 26;

        var labelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = fontSize,
            normal = { textColor = Color.white }
        };

        GUI.Label(new Rect(20, 20, 250, 40), $"Score: {Score}", labelStyle);
        GUI.Label(new Rect(Screen.width - 180, 20, 160, 40), $"Coin: {Coins}", labelStyle);

        if (!IsGameOver) return;

        var centerStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 38,
            alignment = TextAnchor.MiddleCenter,
            normal = { textColor = Color.red }
        };

        GUI.Label(new Rect(0, Screen.height * 0.3f, Screen.width, 50), "GAME OVER", centerStyle);

        var buttonRect = new Rect(Screen.width * 0.5f - 80, Screen.height * 0.5f, 160, 48);
        if (GUI.Button(buttonRect, "Play Again"))
        {
            RestartRun();
        }
    }
}
