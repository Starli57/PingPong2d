
using UnityEngine;

public static class InputManager
{   
    public static Vector3 GetCursorPosition()
    {
        if (Input.touchCount > 0)
            return Input.touches[0].position;

        return Input.mousePosition;
    }
}
