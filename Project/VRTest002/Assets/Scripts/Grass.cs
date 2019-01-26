using UnityEngine;

public class Grass : MonoBehaviour {
  private Vector3 startScale;

  private void Start() {
    startScale = transform.localScale;
  }

  public void SetSize(float size) {
    transform.localScale = Vector3.Lerp(Vector3.zero, startScale, size);
  }
}
