using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour {

    public GameObject corridor;

	void Start ()
    {
        Instantiate(corridor, transform.position + transform.forward * 4, transform.rotation);
	}
}
