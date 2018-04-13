using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoom4 : MonoBehaviour {

    public GameObject corridor;
    public GameObject WayRoom1;
    GameController gc;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (!gc.isLoad)
        {
            Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 4, transform.up * 10);
            Ray ray11 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 8, transform.up * 10);
            Ray ray2 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 4, transform.up * 10);
            Ray ray22 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 8, transform.up * 10);
            Ray ray3 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.right * 4, transform.up * 10);
            Ray ray33 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.right * 8, transform.up * 10);

            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
                Instantiate(corridor, transform.position + transform.forward * 4, transform.rotation);
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(WayRoom1, transform.position + transform.forward * 4, transform.rotation * Quaternion.Euler(0f, 180f, 0f));


            if (!Physics.Raycast(ray2, 10f) && !Physics.Raycast(ray22, 10f))
                Instantiate(corridor, transform.position + transform.right * 4, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
            else if (!Physics.Raycast(ray2, 10f))
                Instantiate(WayRoom1, transform.position + transform.right * 4, transform.rotation * Quaternion.Euler(0f, 180f, 0f) * Quaternion.Euler(0f, 90f, 0f));


            if (!Physics.Raycast(ray3, 10f) && !Physics.Raycast(ray33, 10f))
                Instantiate(corridor, transform.position - transform.right * 4, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
            else if (!Physics.Raycast(ray3, 10f))
                Instantiate(WayRoom1, transform.position - transform.right * 4, transform.rotation * Quaternion.Euler(0f, 180f, 0f) * Quaternion.Euler(0f, -90f, 0f));
        }
    }
}
