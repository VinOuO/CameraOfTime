using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviour
{
    public RoomScene CurrentRoomScene = RoomScene.PersentRoom;
    void Start()
    {
        InitRoomScene();
    }

    void Update()
    {
        if(AltControlManager.Instance.GetButton(button: AltControlManager.ButtonName.Button3, state: AltControlManager.ButtonState.Pressing))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || AltControlManager.Instance.LensDelta > 0f)
            {
                SwitchRoomScene(SwitchMode.Pervious);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || AltControlManager.Instance.LensDelta < 0f)
            {
                SwitchRoomScene(SwitchMode.Next);
            }
        }
    }

    public void InitRoomScene()
    {
        CurrentRoomScene++;
        CurrentRoomScene = (RoomScene)((int)CurrentRoomScene % (int)RoomScene.Max);
        Debug.Log(CurrentRoomScene);
        SceneManager.LoadScene(CurrentRoomScene.ToString(), LoadSceneMode.Additive);
    }

    bool IsSwitchingScene = false;
    IEnumerator CoolingDownSwitchScene()
    {
        IsSwitchingScene = true;
        yield return new WaitForSeconds(2f);
        IsSwitchingScene = false;
    }

    public void SwitchRoomScene(SwitchMode mode)
    {
        if (IsSwitchingScene)
        {
            return;
        }
        StartCoroutine(CoolingDownSwitchScene());
        if (CurrentRoomScene != RoomScene.None)
        {
            SceneManager.UnloadSceneAsync(CurrentRoomScene.ToString(), UnloadSceneOptions.None);
        }
        CurrentRoomScene += (mode == SwitchMode.Pervious) ? -1 : 1;
        CurrentRoomScene = (RoomScene)(((int)CurrentRoomScene + (int)RoomScene.Max) % (int)RoomScene.Max);
        Debug.Log(CurrentRoomScene);
        SceneManager.LoadScene(CurrentRoomScene.ToString(), LoadSceneMode.Additive);
    }

    public enum SwitchMode
    {
        Pervious = 1,
        Next = 2,
    }

    public enum RoomScene
    {
        None = -1,
        PastRoom = 0,
        PersentRoom = 1,
        FutureRoom = 2,
        Max = 3,
    }
}
