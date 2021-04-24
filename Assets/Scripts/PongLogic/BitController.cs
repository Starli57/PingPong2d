
using UnityEngine;

public class BitController : MonoBehaviour
{
    [SerializeField] private bool _x = false;
    [SerializeField] private bool _y = false;

    private ScreenLimits _screenLimits;
    private Bounds _bounds;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _screenLimits = FindObjectOfType<ScreenLimits>();
        _bounds = GetComponent<SpriteRenderer>().bounds;
    }

    private void Update()
    {
        Vector2 cursorPosition = InputManager.GetCursorPosition();

        float xAspect = cursorPosition.x / Screen.width;
        float yAspect = cursorPosition.y / Screen.height;
        
        float x = Mathf.Lerp(_screenLimits.LeftBorder(), _screenLimits.RightBorder(), xAspect);
        float y = Mathf.Lerp(_screenLimits.BottomBorder(), _screenLimits.TopBorder(), yAspect);

        Vector2 targetPosition = new Vector2(
            _x ? x : transform.position.x, 
            _y ? y : transform.position.y);

        transform.position = _screenLimits.ClampPositionByScreen(targetPosition, _bounds);
    }
}
