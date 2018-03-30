using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoom1 : MonoBehaviour {

    //private Collider[] objs;
    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 1f);
        transform.parent = null;
        transform.Rotate(0f, 180f, 0f);

    }


}
