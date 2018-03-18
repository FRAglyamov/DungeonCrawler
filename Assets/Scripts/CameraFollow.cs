using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public Vector3 viewOffset;
    public float followSpeed;
    public float turningSpeed;


    void FixedUpdate ()
    {
        Vector3 offsetDifference = Quaternion.Inverse(target.rotation) * (transform.position - target.position) - offset;

        float multiplier = offsetDifference.magnitude;

        transform.position = Vector3.Lerp(transform.position, target.position + target.rotation * offset, followSpeed * Time.fixedDeltaTime * multiplier);
        Vector3 directionToHead = (target.position + viewOffset) - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToHead), turningSpeed * Time.fixedDeltaTime);
	}
}
