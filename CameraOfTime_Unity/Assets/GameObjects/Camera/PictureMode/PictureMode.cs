#define ZoomDode1
using UnityEngine;
public class PictureMode : MonoBehaviour
{
    public Vector2 ZoomClampValue = Vector2.one;
    void Start()
    {
        
    }

    void Update()
    {
        if (AltControlManager.Instance.GetButton(button: AltControlManager.ButtonName.Button3, state: AltControlManager.ButtonState.Released) && AltControlManager.Instance.PressingTime <= 0.5f)
        {
            if (CameraBehavior.Instance.Button.Press())
            {
                AlbumMode.Instance.AlbumPics.Add(AlbumMode.Instance.GetTextureFromCamera());
                Debug.Log("TakePic");
            }
        }
        //Debug.Log("ZoomValue: " + AltControlManager.Instance.GetLens(AltControlManager.LensName.Zoom));
#if ZoomDode1
        SetZoom(AltControlManager.Instance.GetLens(AltControlManager.LensName.Zoom));
#else
        ZoomCamera(AltControlManager.Instance.GetLens(AltControlManager.LensName.Zoom) * Time.deltaTime * 100f);
#endif
    }

    void ZoomCamera(float degree)
    {
        CameraBehavior.Instance.Camera.fieldOfView -= degree;
    }

    void SetZoom(float degree)
    {
        //Debug.Log("Camdegree: " + degree);
        //Debug.Log("CamFOV: " + Mathf.Lerp(degree, ZoomClampValue.x, ZoomClampValue.y));
        CameraBehavior.Instance.Camera.fieldOfView = 120f + Mathf.Lerp(degree, ZoomClampValue.x, ZoomClampValue.y) * 100f;
    }
}
