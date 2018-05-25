using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Orb : MonoBehaviour {

    AudioManager audioManager;
    private void Start()
    {
        audioManager = audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //audioManager.Play("Orb");
            List<GameObject> levelList = GameObject.FindGameObjectsWithTag("Level").ToList();
            foreach (var item in levelList)
            {
                item.transform.Find("Minimap Icon").gameObject.SetActive(true);
            }
        }
    }
}
