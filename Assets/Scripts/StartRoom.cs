using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour {

    public GameObject corridor;
    GameController gc;

    void Start ()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (!gc.isLoad)
        {
            Instantiate(corridor, transform.position + transform.forward * 4, transform.rotation);
        }
	}
}
