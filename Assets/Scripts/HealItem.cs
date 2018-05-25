using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour {

    AudioManager audioManager;

    private void Start()
    {
        audioManager = audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.Play("Eat");
            other.GetComponent<PlayerController>().Healed(20);
            Destroy(gameObject);
        }
    }
}
