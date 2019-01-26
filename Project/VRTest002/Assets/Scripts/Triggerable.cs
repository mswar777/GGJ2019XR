using UnityEngine;

public class Triggerable : MonoBehaviour
{
  public delegate void TriggerEventDelegate(Triggerable sender, Collider collider);
  public TriggerEventDelegate onTriggerEvent;

  [SerializeField]
  private string triggerTag;

  private void OnTriggerEnter(Collider other) {
    if (other.tag == triggerTag) {
      onTriggerEvent?.Invoke(this, other);
    }
  }
}
