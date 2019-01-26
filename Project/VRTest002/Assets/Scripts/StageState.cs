using System;
using UnityEngine;

public class StageState : MonoBehaviour {
  public float startTime = 30.0f;
  [SerializeField]
  private float currentTime;
  public float CurrentTime {
    get { return currentTime; }
  }
  [SerializeField]
  private bool timeOver = false;
  public bool IsTimeOver {
    get { return timeOver; }
  }

  public event EventHandler onTimeOverEvent;
  public event EventHandler onTimeChangeEvent;

  void Start() {
    currentTime = startTime;
  }

  void Update() {
    if (!timeOver) {
      currentTime -= Time.deltaTime;
      onTimeChangeEvent?.Invoke(this, null);
      if (currentTime <= 0.0f) {
        timeOver = true;
        onTimeOverEvent?.Invoke(this, null);
      }
    }
  }
}
