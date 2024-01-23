using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumMode : MonoBehaviour
{
    public static AlbumMode Instance;
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
        if (AltControlManager.Instance.GetButton(AltControlManager.ButtonName.RightArrow, AltControlManager.ButtonState.Pressed))
        {
            NextPic();
            Debug.Log("NextPic");
        }
    }

    public void NextPic()
    {
        CurrentPictureIndex++;
        CurrentPictureIndex %= AlbumPics.Count;
        SetDisplayPicture(CurrentPictureIndex);
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
