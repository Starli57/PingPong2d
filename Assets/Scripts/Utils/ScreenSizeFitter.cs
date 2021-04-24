using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeFitter : MonoBehaviour
{
    [SerializeField] private bool _fitX;
    [SerializeField] private bool _fitY;

    private ScreenLimits _screenLimits;

    private void Awake()
    {
        _screenLimits = FindObjectOfType<ScreenLimits>();

        transform.localScale = new Vector3(
            _fitX ? _screenLimits.ScreenSizeUnits.x : transform.localScale.x,
            _fitY ? _screenLimits.ScreenSizeUnits.y : transform.localScale.y,
            transform.localScale.z);
    }
}
