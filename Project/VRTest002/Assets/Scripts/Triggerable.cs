using UnityEngine;

public class Triggerable : MonoBehaviour
{
  public delegate void TriggerEventDelegate(Triggerable sender, Collider collider);
  public TriggerEventDelegate onTriggerEvent;

  [SerializeField]
  private string triggerTag = "";

  private bool enable = true;

  private void OnTriggerEnter(Collider other) {
    if (enable && other.tag == triggerTag) {
      onTriggerEvent?.Invoke(this, other);
    }
  }

  public void Enable() {
    enable = true;
  }

  public void Disable() {
    enable = false;
  }
}
