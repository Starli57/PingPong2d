using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenEdgeHolder : MonoBehaviour
{
    [SerializeField] private ScreenEdge _screenEdge;

    private ScreenLimits _screenLimits;

    private Bounds _bounds;

    private void Awake()
    {
        _screenLimits = FindObjectOfType<ScreenLimits>();
        _bounds = GetComponent<SpriteRenderer>().bounds;
    }

    private void Update()
    {
        _screenLimits.HoldToEdge(transform, _bounds, _screenEdge);
    }
}
