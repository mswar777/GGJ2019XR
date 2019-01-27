using UnityEngine;

public class FreeCamera : MonoBehaviour {
  public float sensitivity = 10f;
  public float maxYAngle = 80f;
  public float forceValue = 1000;
  private Vector2 currentRotation;

  public GameObject ballPrefab;

  void Update() {
    currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
    currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
    currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
    currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
    Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    if (Input.GetMouseButtonDown(0)) {
      Cursor.lockState = CursorLockMode.Locked;
      GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
      ball.GetComponent<Rigidbody>().AddForce(transform.forward * forceValue);
    }
  }
}
