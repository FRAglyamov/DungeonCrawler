using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("main");
            GameController.Instance.isNavMeshBuild = false;
        }
    }
}
