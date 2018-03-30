using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCorridorRight : MonoBehaviour {

    public GameObject WayRoom1;
    public GameObject WayRoom2;
    public GameObject WayRoom4;
    GameController gc;
    Transform tr;

    void Start ()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(1f, 0f, 0f);
        transform.parent = null;

        tr = this.gameObject.GetComponent<Transform>();
        tr.Rotate(0f, 90f, 0f);
        int rnd = Random.Range(0, 100);
        if (rnd >50 && gc.WayRoom2 > 0)
        {
                Instantiate(WayRoom2, tr.position, tr.rotation, this.tr);
                gc.WayRoom2 -= 1;
        }
        else if (gc.WayRoom4 > 0)
        {
            Instantiate(WayRoom4, tr.position, tr.rotation, this.tr);
            gc.WayRoom4 -= 1;
        }
        else 
        {
            Instantiate(WayRoom1, tr.position, tr.rotation, this.tr);
        }
    }
}
