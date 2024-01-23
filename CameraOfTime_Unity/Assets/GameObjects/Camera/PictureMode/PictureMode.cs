using UnityEngine;

public class PictureMode : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (AltControlManager.Instance.GetButton(AltControlManager.ButtonName.Center, AltControlManager.ButtonState.Pressed))
        {
            if (CameraBehavior.Instance.Button.Press())
            {
                AlbumMode.Instance.AlbumPics.Add(AlbumMode.Instance.GetTextureFromCamera());
                Debug.Log("TakePic");
            }
        }
        ZoomCamera(AltControlManager.Instance.GetLens(AltControlManager.LensName.Zoom) * Time.deltaTime * 100f);
    }

    void ZoomCamera(float degree)
    {
        CameraBehavior.Instance.Camera.fieldOfView -= degree;
    }
}
