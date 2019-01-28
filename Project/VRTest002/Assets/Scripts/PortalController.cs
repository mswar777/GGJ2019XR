using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour {
  private delegate void SimpleDelegate();

  [SerializeField]
  private Triggerable portalA;
  [SerializeField]
  private Triggerable portalB;

  private void Start() {
    portalA.onTriggerEvent += OnPortalTrigger;
    portalB.onTriggerEvent += OnPortalTrigger;
  }

  private void OnPortalTrigger(Triggerable sender, Collider collider) {

    Triggerable moveTo = portalA == sender ? portalB : portalA;
    collider.transform.position = moveTo.transform.position;
    moveTo.Disable();
    StartCoroutine(DelayCall(1.0f, () => { moveTo.Enable(); }));
  }

  private IEnumerator DelayCall(float delay, SimpleDelegate callback) {
    yield return new WaitForSeconds(delay);
    callback();
  }
}
