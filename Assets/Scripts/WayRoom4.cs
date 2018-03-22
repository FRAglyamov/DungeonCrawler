using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoom4 : MonoBehaviour {

    public GameObject corridor;
    Transform tr;
    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 0.5f);
        transform.parent = null;

        tr = this.gameObject.GetComponent<Transform>();
        Instantiate(corridor, tr.position, tr.rotation, this.tr);
        //Vector3 rotated = new Vector3(tr.rotation.eulerAngles.x, tr.rotation.eulerAngles.y + 90f, tr.rotation.eulerAngles.z);
        //Vector3 rotated2 = new Vector3(tr.rotation.eulerAngles.x, tr.rotation.eulerAngles.y - 90f, tr.rotation.eulerAngles.z);
        Instantiate(corridor, tr.position, tr.rotation, this.tr);
        Instantiate(corridor, tr.position, tr.rotation, this.tr);
    }
}
