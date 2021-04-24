using System;
using UnityEngine;
using UnityEngine.UI;

public class BallColorButton : MonoBehaviour
{
    public Action<Color> onPressed;

    public Color GetColor()
    {
        return _background.color;
    }

    public void SetColor(Color color)
    {
        _background.color = color;
    }

    private Button _button;
    private Image _background;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _background = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnPressed);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPressed);
    }

    private void OnPressed()
    {
        onPressed?.Invoke(GetColor());
    }
}
