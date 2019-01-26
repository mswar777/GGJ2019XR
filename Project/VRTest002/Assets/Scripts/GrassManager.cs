using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour {
  public StageState stageState;

  public List<Grass> grassArray;

  [SerializeField]
  private float sizeChangePeriod = 1;
  [SerializeField]
  private AnimationCurve sizeChangePattern;
  private int currentSizeTime;

  void Start() {
    stageState.onTimeChangeEvent += OnTimeChange;
    stageState.onTimeOverEvent += OnTimeOver;
  }

  private void OnTimeChange(object sender, System.EventArgs args) {
    if (currentSizeTime != (int)(stageState.CurrentTime / sizeChangePeriod)) {
      currentSizeTime = (int)(stageState.CurrentTime / sizeChangePeriod);
      float currentSizeFloat = Mathf.Clamp01(stageState.CurrentTime / stageState.startTime);
      foreach(Grass grass in grassArray) {
        grass.SetSize(sizeChangePattern.Evaluate(currentSizeFloat));
      }
    }
  }

  private void OnTimeOver(object sender, System.EventArgs args) {
    foreach (Grass grass in grassArray) {
      grass.SetSize(0.0f);
    }
  }
}
