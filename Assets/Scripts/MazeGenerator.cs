using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject corridor;
    Transform tr;
	// Use this for initialization
	void Start () {
        tr = this.gameObject.GetComponent<Transform>();
        //Vector3 corridorPos = new Vector3(tr.position.x + (4 * Mathf.Sin(Mathf.Deg2Rad * tr.rotation.y)), tr.position.y, tr.position.z + (4 * (Mathf.Cos(Mathf.Deg2Rad * tr.rotation.y))));
        //Vector3 corridorPos = new Vector3(tr.position.x, tr.position.y, tr.position.z );
        Instantiate(corridor, tr.position, tr.rotation, this.tr);
	}
}
