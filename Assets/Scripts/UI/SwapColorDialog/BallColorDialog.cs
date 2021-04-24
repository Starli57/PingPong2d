using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorDialog : MonoBehaviour
{
    private BallColorDialogView _view;
    private PongController _pongController;

    private void Awake()
    {
        _pongController = FindObjectOfType<PongController>();

        _view = GetComponent<BallColorDialogView>();
        _view.Initialize(GetColors());

        _view.onColorPressed += SaveTheColor;
        _view.onClosePressed += CloseDialog;
    }

    private void OnDestroy()
    {
        if (_view != null)
        {
            _view.onColorPressed -= SaveTheColor;
            _view.onClosePressed -= CloseDialog;
        }
    }

    private List<Color> GetColors()
    {
        int colorsCount = 12;
        List<Color> colors = new List<Color>();

        for (int i = 0; i < colorsCount; i++)
        {
            Color color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, 1);
            colors.Add(color);
        }

        return colors;
    }

    private void SaveTheColor(Color color)
    {
        _pongController.ball.ChangeColor(color);
    }
    
    private void CloseDialog()
    {
        UIManager.instance.DestroyDialog(this.gameObject);
    }
}
