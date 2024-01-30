using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject Parent;
    public static CameraBehavior Instance;
    public CameraButtonBehavior Button;
    public Camera Camera;
    public CameraMode CurrentMode;
    public List<GameObject> ModeCanvasList;

    private void OnEnable()
    {
        Instance = this;
    }

    void Start()
    {
        SetMode((int)CurrentMode);
        Init();
    }


    void Update()
    {
        if (AltControlManager.Instance.GetButton(button: AltControlManager.ButtonName.Button3, state: AltControlManager.ButtonState.Released) && AltControlManager.Instance.PressingTime >= 0.5f && AltControlManager.Instance.PressingTime < 2f)
        {
            SwitchMode();
            Debug.Log("SwitchMode");
        }
        //Debug.Log("Mask:" + Camera.cullingMask);
    }

    public void Init()
    {
        transform.SetParent(Parent.transform);
        transform.localPosition = Vector3.zero + Vector3.right * 0.05f + Vector3.up * -0.05f; 
        transform.localRotation = Quaternion.identity * Quaternion.EulerRotation(new Vector3(-150,0,0)); 
    }

    public void SwitchMode()
    {
        CurrentMode++;
        CurrentMode = (CameraMode)((int)CurrentMode % (int)CameraMode.Max);

        switch (CurrentMode)
        {
            case CameraMode.BlueLight:
                Camera.cullingMask = 63;
                break;
            case CameraMode.Picture:
                Camera.cullingMask = 119;
                break;
        }

        SetMode((int)CurrentMode);
    }

    void SetMode(int index)
    {
        foreach (GameObject canvas in ModeCanvasList)
        {
            canvas.SetActive(false);
        }
        ModeCanvasList[index].SetActive(true);
    }

    public enum CameraMode
    {
        None = -1,
        Picture = 0,
        Album = 1,
        BlueLight = 2,
        Max = 3,
    }
}
