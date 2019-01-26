using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour {
  private class TransformData {
    public Vector3 position;
    public Vector3 rotation;
  }

  [SerializeField]
  private GameObject[] grassPrefabs;
  [SerializeField]
  private Transform spawnAnchor;

  private System.Random random = new System.Random();

  private List<GameObject> grasses = new List<GameObject>();

  private void Start() {
    TransformData[] transformDatas = GeneratePositions(transform.position, spawnAnchor.position, 10, 30);
    StartCoroutine(SpawnGrassInstances(grassPrefabs, transformDatas));
  }

  private TransformData[] GeneratePositions(Vector3 center, Vector3 spawnPosition, float range, int count) {
    TransformData[] transformDatas = new TransformData[count];

    float r = Vector3.Distance(center, spawnPosition);
    float centralAngle = range / r * (360.0f / Mathf.PI);
    float spawnPosAngleX = Mathf.Atan2(center.y - spawnPosition.y, spawnPosition.x - center.x) * (180 / Mathf.PI);
    spawnPosAngleX *= -1;
    float minAngleX = spawnPosAngleX - centralAngle / 2.0f;
    float maxAngleX = spawnPosAngleX + centralAngle / 2.0f;
    float spawnPosAngleY = Mathf.Atan2(center.z - spawnPosition.z, spawnPosition.x - center.x) * (180 / Mathf.PI);
    spawnPosAngleY *= -1;
    float minAngleY = spawnPosAngleY - centralAngle / 2.0f;
    float maxAngleY = spawnPosAngleY + centralAngle / 2.0f;

    for (int i = 0; i < count; i++) {
      float angleX = (float)random.NextDouble() * (maxAngleX - minAngleX) + minAngleX;
      float angleY = (float)random.NextDouble() * (maxAngleY - minAngleY) + minAngleY;

      transformDatas[i] = new TransformData();
      transformDatas[i].position = CoordinateToVector3(angleY, angleX, r);
      transformDatas[i].rotation = Vector3.zero;
    }

    return transformDatas;
  }

  private IEnumerator SpawnGrassInstances(GameObject[] prefabs, TransformData[] transformDatas) {
    foreach(TransformData data in transformDatas) {
      GameObject grass = Instantiate(prefabs[random.Next(0, prefabs.Length)], data.position, Quaternion.Euler(data.rotation), transform);
      grasses.Add(grass);
      yield return null;
    }
  }

  private static Vector3 CoordinateToVector3(float lat, float lon, float alt) {
    Vector3 result = new Vector3();
    float latRad = lat * Mathf.Deg2Rad;
    float lonRad = lon * Mathf.Deg2Rad;
    result.x = alt * Mathf.Cos(latRad) * Mathf.Cos(lonRad);
    result.z = alt * Mathf.Cos(latRad) * Mathf.Sin(lonRad);
    result.y = alt * Mathf.Sin(latRad);
    return result;
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      foreach (GameObject go in grasses) {
        Destroy(go);
      }
      grasses.Clear();
      TransformData[] transformDatas = GeneratePositions(transform.position, spawnAnchor.position, 10, 30);
      StartCoroutine(SpawnGrassInstances(grassPrefabs, transformDatas));
    }
  }
}
