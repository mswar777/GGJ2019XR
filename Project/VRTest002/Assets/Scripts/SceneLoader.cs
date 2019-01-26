using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public enum SceneState
{
    TITLE_SCENE = 0,
    //GAME_SCENE,
    VR_STAGE01,
    VR_STAGE02,
    VR_STAGE03,
    ENDING_SCENE,
    GAME_OVER_SCENE,
}

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneWithFade(SceneState scene)
    {
        var sceneName = "";
        switch (scene)
        {
            case SceneState.TITLE_SCENE:
                sceneName = "SceneTitle";
                break;
            //case SceneState.GAME_SCENE:
            //    sceneName = "SceneGame";
            //    break;
            case SceneState.VR_STAGE01:
                sceneName = "Stage01";
                break;
            case SceneState.VR_STAGE02:
                sceneName = "Stage02";
                break;
            case SceneState.VR_STAGE03:
                sceneName = "Stage03";
                break;
            case SceneState.ENDING_SCENE:
                sceneName = "SceneEnding";
                break;
            case SceneState.GAME_OVER_SCENE:
                sceneName = "SceneGameOver";
                break;
        }
        SteamVR_LoadLevel.Begin(sceneName);
    }

    public void LoadScene(SceneState scene)
    {
        var sceneName = "";
        switch (scene)
        {
            case SceneState.TITLE_SCENE:
                sceneName = "SceneTitle";
                break;
            //case SceneState.GAME_SCENE:
            //    sceneName = "SceneGame";
            //    break;
            case SceneState.VR_STAGE01:
                sceneName = "Stage01";
                break;
            case SceneState.VR_STAGE02:
                sceneName = "Stage02";
                break;
            case SceneState.VR_STAGE03:
                sceneName = "Stage02";
                break;
            case SceneState.ENDING_SCENE:
                sceneName = "SceneEnding";
                break;
            case SceneState.GAME_OVER_SCENE:
                sceneName = "SceneGameOver";
                break;
        }
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
    }
}
