using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    AudioManager audioManager;
    bool isActivated = false;

    private void Start()
    {
        audioManager = audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isActivated)
        {
            //audioManager.Play("Spikes");
            transform.Find("SpikesCone").gameObject.SetActive(true);
            isActivated = true;
            other.GetComponent<PlayerController>().Damaged(10);
        }
    }
}
