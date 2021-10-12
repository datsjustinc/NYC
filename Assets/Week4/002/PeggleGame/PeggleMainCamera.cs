using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PeggleMainCamera : MonoBehaviour {
    public float intensity = 1.0f; bool isShaking = false; public float shakeTime = 1.0f; public void ShakeCamera() { if (!isShaking) { isShaking = true; StartCoroutine(ShakeCameraRoutine()); } else { shakeTime += 0.1f; } }
    IEnumerator ShakeCameraRoutine() {
        while (shakeTime > 0.0f) {
            shakeTime -= Time.deltaTime; transform.position = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity),
transform.position.z); yield return null;
        }
        shakeTime = 0.15f; isShaking = false;
    }
}