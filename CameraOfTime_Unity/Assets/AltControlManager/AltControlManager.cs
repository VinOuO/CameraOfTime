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
    private void Start()
    {
        StartCoroutine(GettingLensDelta());
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            PressedTime = Time.time;
        }
        if (Input.GetKeyUp("joystick button 1"))
        {
            ReleasedTime = Time.time;
            PressingTime = ReleasedTime - PressedTime;
        }
    }

    public float LensDelta = 0;
    IEnumerator GettingLensDelta()
    {
        float valueBefore = 0f;
        float valueNow = 0f;
        while (true)
        {
            valueNow = GetLens();
            LensDelta = (valueBefore - valueNow) *Time.deltaTime;
            valueBefore = valueNow;
            yield return new WaitForEndOfFrame();
        }
    }

    public float GetLens(LensName lens = LensName.Zoom)
    {
        return Input.GetAxis("Horizontal");
    }

    public float PressingTime = 0;
    public float PressedTime = 0, ReleasedTime = 0;
    public bool GetButton(ButtonName button = ButtonName.Button3, ButtonState state = ButtonState.None)
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
        Button3 = 1,
        Button2 = 2,
        Button1 = 3,
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
