using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class CameraButtonBehavior : MonoBehaviour
{
    public Vector3 NormalPos, PressedPos;


    public bool Press()
    {
        if (IsPressing)
        {
            return false;
        }
        StartCoroutine(Pressing());
        return true;
    }

    bool IsPressing = false;
    IEnumerator Pressing()
    {
        IsPressing = true;
        transform.position = PressedPos;
        yield return new WaitForSeconds(0.5f);  
        transform.position = NormalPos;
        IsPressing = false;
    }
}
