using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySceneLoader : MonoBehaviour
{
  [SerializeField]
  private string[] sceneName = null;


  private void Start() {
    // for test
    LoadStage(0);
  }

  public void LoadStage(int stage) {
    if (sceneName.Length <= stage) {
      Debug.LogError("there is no stage #" + stage);
      return;
    }
    SceneManager.LoadScene(sceneName[0], LoadSceneMode.Additive);
  }
}
