using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public T ShowDialog<T>()
    {
        UnityEngine.Object dialog = Resources.Load(typeof(T).Name);
        if (dialog == null)
            throw new Exception("Cant find dialog: " + typeof(T).Name);

        return (Instantiate(dialog, transform) as GameObject).GetComponent<T>();
    }
    
    public void DestroyDialog(GameObject dialog)
    {
        Destroy(dialog);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
