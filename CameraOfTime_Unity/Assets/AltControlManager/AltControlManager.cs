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
        //if (Input.GetKeyDown("joystick button 1"))
        //{
        //    Debug.Log("1");
        //}
        //if (Input.GetKeyDown("joystick button 2"))
        //{
        //    Debug.Log("2");
        //}
        //if (Input.GetKeyDown("joystick button 3"))
        //{
        //    Debug.Log("3");
        //}
        //if (Input.GetKeyDown("joystick button 4"))
        //{
        //    Debug.Log("4");
        //}

        if (GetButton(state: ButtonState.Pressed))
        {
            PressedTime = Time.time;
        }
        if (GetButton(state: ButtonState.Released))
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
        /*
        switch (state)
        {
            case ButtonState.Pressed:
                return Input.GetKeyDown(buttonString);
            case ButtonState.Pressing:
                return Input.GetKey(buttonString);
            case ButtonState.Released:
                return Input.GetKeyUp(buttonString);
        }
        */
        switch (state)
        {
            case ButtonState.Pressed:
                return Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 3") || Input.GetKeyDown("joystick button 4");
            case ButtonState.Pressing:
                return Input.GetKey("joystick button 0") || Input.GetKey("joystick button 1") || Input.GetKey("joystick button 2") || Input.GetKey("joystick button 3") || Input.GetKey("joystick button 4");
            case ButtonState.Released:
                return Input.GetKeyUp("joystick button 0") || Input.GetKeyUp("joystick button 1") || Input.GetKeyUp("joystick button 2") || Input.GetKeyUp("joystick button 3") || Input.GetKeyUp("joystick button 4");
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
        Button3 = 3,
        Button2 = 2,
        Button1 = 1,
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
