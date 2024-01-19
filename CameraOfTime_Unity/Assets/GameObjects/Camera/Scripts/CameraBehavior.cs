using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
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
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Button.Press())
            {
                AlbumManager.Instance.AlbumPics.Add(AlbumManager.Instance.GetTextureFromCamera());
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchMomde();
        }
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
