using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoom4 : MonoBehaviour {

    public GameObject corridor;
    public GameObject corridorLeft;
    public GameObject corridorRight;
    void Start()
    {

        Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 4, transform.up * 10);
        Ray ray2 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 4, transform.up * 10);
        Ray ray3 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.right * 4, transform.up * 10);

        if(!Physics.Raycast(ray1, 10f))
        {
            Instantiate(corridor, transform.position + transform.forward * 4, transform.rotation);
        }
        if (!Physics.Raycast(ray2, 10f))
        {
            Instantiate(corridorRight, transform.position + transform.right * 4, transform.rotation);
        }
        if (!Physics.Raycast(ray3, 10f))
        {
            Instantiate(corridorLeft, transform.position - transform.right * 4, transform.rotation);
        }
    }
}
