using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCorridor : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 1f);
        //this.transform.forward += new Vector3(0f, 0f, 4f);
	}
}
