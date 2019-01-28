using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    public GameObject RigCamera;
    [SerializeField]
    public GameObject MouseCamera;

    // Start is called before the first frame update
    void Awake()
    {
        // VR有効じゃない場合はMouseCamera、有効ならRigCameraをActive化する
        //Valve.VR.SteamVR.RigCameraOnCB = (_) => RigCamera.SetActive((bool)_);
        //Valve.VR.SteamVR.MouseCameraOnCB = (_) => MouseCamera.SetActive((bool)_);
    }

    // Update is called once per frame
    void Update()
    {
        // VR有効じゃない場合用にMouseCameraをON
        if (Input.GetKeyUp(KeyCode.M))
        {
            RigCamera.SetActive(false);
            MouseCamera.SetActive(true);
        }        
    }
}
