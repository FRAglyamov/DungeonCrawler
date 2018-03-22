using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoom1 : MonoBehaviour {

    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 0.5f);
        transform.parent = null;
        //transform.Rotate(0f, 90f, 0f);
    }
}
