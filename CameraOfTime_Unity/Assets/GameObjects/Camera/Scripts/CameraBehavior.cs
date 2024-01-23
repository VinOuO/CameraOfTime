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
        if (AltControlManager.Instance.GetButton(AltControlManager.ButtonName.UpArrow, AltControlManager.ButtonState.Pressed))
        {
            SwitchMomde();
            Debug.Log("SwitchMode");
        }
    }

    public void Init()
    {
        transform.SetParent(Parent.transform);
        transform.localPosition = Vector3.zero; 
        transform.localRotation = Quaternion.identity; 
    }

    public void SwitchMomde()
    {
        CurrentMode++;
        CurrentMode = (CameraMode)((int)CurrentMode % (int)CameraMode.Max);

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
