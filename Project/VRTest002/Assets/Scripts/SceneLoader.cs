using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public enum SceneState
{
    TITLE_SCENE = 0,
    GAME_SCENE = 1,
    ENDING_SCENE = 2,
    GAME_OVER_SCENE = 3,
    TEST_SCENE = 5,
    TEST_STAGE = 4,
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
            case SceneState.GAME_SCENE:
                sceneName = "SceneGame";
                break;
            case SceneState.ENDING_SCENE:
                sceneName = "SceneEnding";
                break;
            case SceneState.GAME_OVER_SCENE:
                sceneName = "SceneGameOver";
                break;
            case SceneState.TEST_SCENE:
                sceneName = "TestScene";
                break;
            case SceneState.TEST_STAGE:
                sceneName = "TestStage";
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
            case SceneState.GAME_SCENE:
                sceneName = "SceneGame";
                break;
            case SceneState.ENDING_SCENE:
                sceneName = "SceneEnding";
                break;
            case SceneState.GAME_OVER_SCENE:
                sceneName = "SceneGameOver";
                break;
            case SceneState.TEST_SCENE:
                sceneName = "TestScene";
                break;
            case SceneState.TEST_STAGE:
                sceneName = "TestStage";
                break;
        }
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
    }
}
