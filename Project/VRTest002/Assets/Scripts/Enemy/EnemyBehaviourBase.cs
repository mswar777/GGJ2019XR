using UnityEngine;

public abstract class EnemyBehaviourBase : MonoBehaviour
{
  public void Update() {
    this.Move();
  }

  protected virtual void Move() {
  }
}
