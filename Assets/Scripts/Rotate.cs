using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Vector3 rotation;
    void Start()
    {
        transform.Rotate(rotation);
    }
}
