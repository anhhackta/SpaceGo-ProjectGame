using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MobileCameraScaler : MonoBehaviour
{
    [Header("Reference device")]
    [Tooltip("9:16 portrait reference by default")]
    public float referenceAspect = 9f / 16f;

    [Tooltip("Base orthographic size at reference aspect")]
    public float baseOrthographicSize = 5.6f;

    private Camera _cam;
    private int _lastW;
    private int _lastH;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        Apply();
    }

    private void Update()
    {
        if (_lastW != Screen.width || _lastH != Screen.height)
        {
            Apply();
        }
    }

    private void Apply()
    {
        if (_cam == null)
        {
            _cam = GetComponent<Camera>();
            if (_cam == null) return;
        }

        _cam.orthographic = true;

        var currentAspect = Mathf.Max(0.1f, _cam.aspect);
        var targetHalfWidth = baseOrthographicSize * referenceAspect;
        var adjustedSize = Mathf.Max(baseOrthographicSize, targetHalfWidth / currentAspect);
        _cam.orthographicSize = adjustedSize;

        _lastW = Screen.width;
        _lastH = Screen.height;
    }
}
