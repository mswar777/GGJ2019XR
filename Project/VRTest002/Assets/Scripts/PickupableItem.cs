using UnityEngine;

public class PickupableItem : MonoBehaviour
{
  public delegate void PickUpEventDelegate(PickupableItem sender, GameObject reciever);
  public PickUpEventDelegate onPickUpEvent;

  [SerializeField]
  private string triggerTag;

  private void OnTriggerEnter(Collider other) {
    if (other.tag == triggerTag) {
      Debug.Log("picked up");
      onPickUpEvent?.Invoke(this, other.gameObject);
    }
  }
}
