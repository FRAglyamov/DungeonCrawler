using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    AudioManager audioManager;

    private void Start()
    {
        audioManager = audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.Play("Portal");
            SceneManager.LoadScene("main");
            GameController.Instance.isNavMeshBuild = false;
        }
    }
}
