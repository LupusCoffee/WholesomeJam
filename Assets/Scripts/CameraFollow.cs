using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float followSpeed;
    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position + cameraOffset;
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, followSpeed * Time.fixedDeltaTime);

        transform.position = smoothPos;
    }
}
