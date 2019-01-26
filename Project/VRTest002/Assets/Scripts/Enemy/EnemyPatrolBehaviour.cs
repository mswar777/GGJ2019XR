using UnityEngine;

public class EnemyPatrolBehaviour : EnemyBehaviourBase
{
  public enum PatrolType {
    Once,
    PingPong,
    Loop
  }

  [System.Serializable]
  public class RouteSection {
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float duration = 3.0f;
    public AnimationCurve curve;
  }

  [SerializeField]
  private PatrolType patrolType;

  public RouteSection[] route;

  private int currentSectionIndex;
  private float currentProgress = 0.0f;
  private bool movingForward = true;
  private bool isOver = false;
  private Vector3 origin_pos;

  private void Awake()
  {
    origin_pos = transform.position;
    
  }

  protected override void Move() {
    if (route.Length <= 0 || isOver) {
      return;
    }

    currentProgress = Mathf.Clamp01(currentProgress + (Time.deltaTime / route[currentSectionIndex].duration));
    
    transform.position = origin_pos;
    if (movingForward) {
      transform.position += Vector3.Lerp(route[currentSectionIndex].startPosition, route[currentSectionIndex].endPosition, route[currentSectionIndex].curve.Evaluate(currentProgress));
    } else {
      transform.position += Vector3.Lerp(route[currentSectionIndex].endPosition, route[currentSectionIndex].startPosition, route[currentSectionIndex].curve.Evaluate(currentProgress));
    }

    if (currentProgress >= 1.0f) {
      GoToNextSection();
    }
  }

  private void GoToNextSection() {
    currentProgress = 0.0f;
    switch (this.patrolType) {
      case PatrolType.Once:
        if (currentSectionIndex < route.Length - 1) {
          currentSectionIndex++;
        } else {
          isOver = true;
        }
        break;
      case PatrolType.PingPong:
        if (movingForward) {
          currentSectionIndex++;
        } else {
          currentSectionIndex--;
        }
        if (movingForward && currentSectionIndex >= route.Length) {
          currentSectionIndex--;
          movingForward = false;
        } else if (!movingForward && currentSectionIndex < 0) {
          currentSectionIndex++;
          movingForward = true;
        }
        break;
      case PatrolType.Loop:
        currentSectionIndex++;
        if (currentSectionIndex >= route.Length) {
          currentSectionIndex = 0;
        }
        break;
    }
  }
}
