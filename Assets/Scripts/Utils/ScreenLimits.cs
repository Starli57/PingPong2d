using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimits : MonoBehaviour
{
    public Vector2 ScreenSizeUnits { get; private set; }

    public float LeftBorder(Bounds bounds) { return _leftBorder + bounds.size.x / 2f; }
    public float TopBorder(Bounds bounds) { return _topBorder - bounds.size.y / 2f; }
    public float RightBorder(Bounds bounds) { return _rightBorder - bounds.size.x / 2f; }
    public float BottomBorder(Bounds bounds) { return _bottomBorder + bounds.size.y / 2f; }

    public float LeftBorder() { return _leftBorder; }
    public float TopBorder() { return _topBorder; }
    public float RightBorder() { return _rightBorder; }
    public float BottomBorder() { return _bottomBorder; }

    public void HoldToEdge(Transform target, Bounds bounds, ScreenEdge screenEdge)
    {
        Vector3 position = target.position;
        switch (screenEdge)
        {
            case ScreenEdge.left:
                position.x = LeftBorder(bounds);
                break;
            case ScreenEdge.top:
                position.y = TopBorder(bounds);
                break;
            case ScreenEdge.right:
                position.x = RightBorder(bounds);
                break;
            case ScreenEdge.bottom:
                position.y = BottomBorder(bounds);
                break;
        }

        target.position = position;
    }

    public Vector3 ClampPositionByScreen(Vector3 position, Bounds bounds)
    {
        return new Vector3(
            Mathf.Clamp(position.x, LeftBorder(bounds), RightBorder(bounds)),
            Mathf.Clamp(position.y, BottomBorder(bounds), TopBorder(bounds)),
            0);
    }

    public bool IsOutOfScreenLimits(Vector3 position)
    {
        return position.x < _leftBorder ||
                position.x > _rightBorder ||
                position.y > _topBorder ||
                position.y < _bottomBorder;
    }


    private float _leftBorder;
    private float _topBorder;
    private float _rightBorder;
    private float _bottomBorder;

    private void Awake()
    {
        Camera mainCamera = Camera.main;
        float clipPlane = mainCamera.nearClipPlane;

        var bottomLeftCorner = mainCamera.ViewportToWorldPoint(new Vector3(0, 0f, clipPlane));
        var topRightCorner = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, clipPlane));

        _leftBorder = bottomLeftCorner.x;
        _topBorder = topRightCorner.y;
        _rightBorder = topRightCorner.x;
        _bottomBorder = bottomLeftCorner.y;

        ScreenSizeUnits = new Vector2(_rightBorder - _leftBorder, _topBorder - _bottomBorder);
    }

}
