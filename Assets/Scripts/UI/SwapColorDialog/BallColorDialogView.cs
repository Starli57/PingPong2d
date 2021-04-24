using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorDialogView : MonoBehaviour
{
    public Action<Color> onColorPressed;
    public Action onClosePressed;

    public void Initialize(List<Color> colors)
    {
        SpawnColorButtons(colors);
    }

    public void OnClosePressed()
    {
        onClosePressed?.Invoke();
    }

    [SerializeField] private BallColorButton _colorButtonPrefab;
    [SerializeField] private Transform _colorsParent;

    private List<BallColorButton> _colorButtons = new List<BallColorButton>();

    private void OnDestroy()
    {
        DestroyColorButtons();
    }

    private void OnColorPressed(Color color)
    {
        onColorPressed?.Invoke(color);
    }

    private void SpawnColorButtons(List<Color> colors)
    {
        foreach(var color in colors)
        {
            var button = Instantiate(_colorButtonPrefab, _colorsParent);
            button.SetColor(color);
            button.onPressed += OnColorPressed;

            _colorButtons.Add(button);
        }
    }

    private void DestroyColorButtons()
    {
        foreach(var colorButton in _colorButtons)
        {
            colorButton.onPressed -= OnColorPressed;
            Destroy(colorButton);
        }

        _colorButtons.Clear();
    }
}
