using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour {

    public GameObject corridor;
    Transform tr;

	void Start ()
    {
        tr = this.gameObject.GetComponent<Transform>();
        Instantiate(corridor, tr.position, tr.rotation, this.tr);
	}
}
