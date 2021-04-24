using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapColorButton : MonoBehaviour
{
    public void ShowDialog()
    {
        UIManager.instance.ShowDialog<BallColorDialog>();
    }
}
