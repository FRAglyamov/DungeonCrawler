﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRoom : MonoBehaviour {

    public GameObject EndRoom;
    public GameObject CorridorRoom;
    public GameObject Hall;

    void Start()
    {
        int roomSize;
        if (transform.localScale.x > 0)
            roomSize = GameController.roomSize;
        else
            roomSize = -GameController.roomSize;
        if (!GameController.Instance.isLoad)
        {

            Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * roomSize, transform.up * 10);
            Ray ray11 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 2 * roomSize, transform.up * 10);


            RaycastHit hit;
            if (Physics.Raycast(ray1, out hit, 10f))
            {
                if ((hit.transform.name.StartsWith("EndRoom") && (hit.transform.rotation != transform.rotation))
                    || (hit.transform.name.StartsWith("Corridor") && (hit.transform.rotation != transform.rotation)))
                {
                    Debug.DrawRay(transform.position, transform.up, Color.red, 200f);
                    Instantiate(EndRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }

            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
            {
                int rnd = Random.Range(0, 100);
                if (rnd > 50 && GameController.Instance.Corridor > 0)
                {
                    Instantiate(CorridorRoom, transform.position + transform.right * roomSize, transform.rotation);
                    GameController.Instance.Corridor -= 1;
                }
                else if (GameController.Instance.Hall > 0)
                {
                    Instantiate(Hall, transform.position + transform.right * roomSize, transform.rotation);
                    GameController.Instance.Hall -= 1;
                }
                else
                    Instantiate(EndRoom, transform.position + transform.right * roomSize, transform.rotation);
            }
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(EndRoom, transform.position + transform.right * roomSize, transform.rotation);
        }
    }
}
