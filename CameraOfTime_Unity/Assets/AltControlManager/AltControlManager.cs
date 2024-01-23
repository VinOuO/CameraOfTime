using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltControlManager : MonoBehaviour
{
    public static AltControlManager Instance;

    private void OnEnable()
    {
        Instance = this;
    }

    public float GetLens(LensName lens = LensName.Zoom)
    {
        return Input.GetAxis("Horizontal");
    }

    public bool GetButton(ButtonName button = ButtonName.UpArrow, ButtonState state = ButtonState.None)
    {
        string buttonString = "joystick button " + (int)button;
        switch (state)
        {
            case ButtonState.Pressed:
                return Input.GetKeyDown(buttonString);
            case ButtonState.Pressing:
                return Input.GetKey(buttonString);
            case ButtonState.Released:
                return Input.GetKeyUp(buttonString);
        }
        return false;
    }

    public enum LensName
    {
        Zoom = 0,
    }

    public enum ButtonName
    {
        Center = 0,
        UpArrow = 1,
        RightArrow = 2,
        LeftArrow = 3,
        DownArrow = 4,
    }

    public enum ButtonState
    {
        None = 0,
        Pressed = 1,
        Pressing = 2,
        Released = 3,
    }
}
