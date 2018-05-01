using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warfog : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            transform.Find("Minimap Icon").gameObject.SetActive(true);
        }
    }
}
