using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : EnemyBehaviourBase
{
  [SerializeField]
  private Vector3 startPosition;
  [SerializeField]
  private Vector3 endPosition;
  [SerializeField]
  private float duration = 3.0f;
  [SerializeField]
  private AnimationCurve curve;

  private float currentProgress = 0.0f;
  private bool movingForward = true;

  protected override void Move() {
    currentProgress = Mathf.Clamp01(currentProgress + ((Time.deltaTime / duration) * (movingForward ? 1.0f : -1.0f)));
    if (currentProgress >= 1.0f) {
      movingForward = false;
    } else if (currentProgress <= 0.0f) {
      movingForward = true;
    }

    transform.position = Vector3.Lerp(startPosition, endPosition, getProgressByCurve(curve, currentProgress, !movingForward));
  }

  private float getProgressByCurve(AnimationCurve animationCurve, float progress, bool opposit = false) {
    if (!opposit) {
      return curve.Evaluate(!opposit ? progress : 1.0f - progress);
    } else {
      return 1.0f - curve.Evaluate(!opposit ? progress : 1.0f - progress);
    }
  }
}
