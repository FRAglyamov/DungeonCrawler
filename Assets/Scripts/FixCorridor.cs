using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCorridor : MonoBehaviour {

    public GameObject WayRoom1;
    public GameObject WayRoom2;
    public GameObject WayRoom4;
    GameController gc;

    void Start ()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 4, transform.up * 10);
        if (!Physics.Raycast(ray1, 10f))
        {

            int rnd = Random.Range(0, 100);
            if (rnd > 50 && gc.WayRoom2 > 0)
            {
                Instantiate(WayRoom2, transform.position + transform.forward * 4, transform.rotation);
                gc.WayRoom2 -= 1;
            }
            else if (gc.WayRoom4 > 0)
            {
                Instantiate(WayRoom4, transform.position + transform.forward * 4, transform.rotation);
                gc.WayRoom4 -= 1;
            }
            else
            {
                Instantiate(WayRoom1, transform.position + transform.forward * 4, transform.rotation);
            }

        }
    }
}
