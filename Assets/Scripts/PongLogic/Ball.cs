using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public const string colorPrefsKey = "BallColor";

    public BallMovementController movementController { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }

    public void Initialize(BallData data)
    {
        spriteRenderer.sprite = data.sprite;

        transform.localScale = data.scale;

        movementController.SetConfiguration(data);
        movementController.ResetState();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
        SaveColor();
    }

    private void Awake()
    {
        movementController = GetComponent<BallMovementController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        LoadColor();
    }

    private void SaveColor()
    {
        PlayerPrefs.SetString(colorPrefsKey, JsonUtility.ToJson(spriteRenderer.color));
    }

    private void LoadColor()
    {
        string savedColor = PlayerPrefs.GetString(colorPrefsKey);
        if (string.IsNullOrEmpty(savedColor))
            return;

        spriteRenderer.color = JsonUtility.FromJson<Color>(savedColor);
    }
    
}
