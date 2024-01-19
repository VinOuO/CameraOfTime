using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumManager : MonoBehaviour
{
    public static AlbumManager Instance;
    public List<Texture> AlbumPics;
    public RawImage Screen;
    public int CurrentPictureIndex = 0;
    private void OnEnable()
    {
        Instance = this;
    }


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentPictureIndex++;
            CurrentPictureIndex %= AlbumPics.Count;
            SetDisplayPicture(CurrentPictureIndex);
        }
        return;
        Debug.Log("JoystickX: " + Input.GetAxis("Horizontal"));
        Debug.Log("JoystickY: " + Input.GetAxis("Vertical"));
        if(Input.GetKey("joystick button 0"))
        {
            Debug.Log("Button 0!");
        }
        if (Input.GetKey("joystick button 1"))
        {
            Debug.Log("Button 1!");
        }
        if (Input.GetKey("joystick button 2"))
        {
            Debug.Log("Button 2!");
        }
        if (Input.GetKey("joystick button 3"))
        {
            Debug.Log("Button 3!");
        }
    }

    public void SetDisplayPicture(int index)
    {
        Screen.texture = AlbumPics[index];
    }

    public Texture2D GetTextureFromCamera()
    {
        Camera camera = CameraBehavior.Instance.Camera;
        Rect rect = new Rect(0, 0, camera.pixelWidth, camera.pixelHeight);
        RenderTexture renderTexture = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 24);
        Texture2D screenShot = new Texture2D(camera.pixelWidth, camera.pixelHeight, TextureFormat.RGBA32, false);

        camera.Render();

        RenderTexture.active = camera.targetTexture;

        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();

        RenderTexture.active = null;
        return screenShot;
    }
}
