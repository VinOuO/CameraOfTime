using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumManager : MonoBehaviour
{
    public static AlbumManager Instance;
    public Texture Current;
    private void OnEnable()
    {
        Instance = this;
    }


    void Start()
    {
        
    }


    void Update()
    {
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


    public Texture2D GetTextureFromCamera()
    {
        Camera camera = CameraBehavior.Instance.Camera;
        Rect rect = new Rect(0, 0, camera.pixelWidth, camera.pixelHeight);
        RenderTexture renderTexture = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 24);
        Texture2D screenShot = new Texture2D(camera.pixelWidth, camera.pixelHeight, TextureFormat.RGBA32, false);

        camera.targetTexture = renderTexture;
        camera.Render();

        RenderTexture.active = renderTexture;

        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();


        camera.targetTexture = null;
        RenderTexture.active = null;
        return screenShot;
    }
}
