using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;

public class TestSceneLoader : MonoBehaviour
{
    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    public SteamVR_Action_Boolean spawn2 = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
    private SteamVR_Behaviour_Pose trackedObj;
    private SceneLoader loader;
    private int stateNum;
    private int nowStateNum;
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        stateNum = Enum.GetValues(typeof(SceneState)).Length;
        nowStateNum = 0;
        loader = GetComponent<SceneLoader>();
        DontDestroyOnLoad(gameObject);
    }

    public void NextSceneLoad()
    {
        nowStateNum = (++nowStateNum) % stateNum;
        var state = (SceneState)Enum.ToObject(typeof(SceneState), nowStateNum);
        loader.LoadSceneWithFade(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            print("Call1");
            NextSceneLoad();
        }
#if false
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("Call2");
            nowStateNum = (++nowStateNum) % stateNum;
            var state = (SceneState)Enum.ToObject(typeof(SceneState), nowStateNum);
            loader.LoadScene(state);
        }
#endif
    }
}
