using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public static CameraBehavior Instance;
    public CameraButtonBehavior Button;
    public Camera Camera;

    private void OnEnable()
    {
        Instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Button.Press())
            {
                AlbumManager.Instance.Current = AlbumManager.Instance.GetTextureFromCamera();
            }
        }
    }
}
