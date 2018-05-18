using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : MonoBehaviour {

    public GameObject corridor;
    public GameObject endRoom;
    public GameObject hall;

    void Start()
    {
        int roomSize = GameController.roomSize;
        if (!GameController.Instance.isLoad)
        {
            Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * roomSize, transform.up * 10);
            Ray ray11 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 2 * roomSize, transform.up * 10);
            Ray ray2 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * roomSize, transform.up * 10);
            Ray ray22 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 2 * roomSize, transform.up * 10);
            Ray ray3 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.right * roomSize, transform.up * 10);
            Ray ray33 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.right * 2 * roomSize, transform.up * 10);

            int rnd;
            rnd = Random.Range(0, 100);

            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
            {
                if (rnd > 50 && GameController.Instance.corridor > 0)
                {
                    Instantiate(corridor, transform.position + transform.forward * roomSize, transform.rotation);
                    GameController.Instance.corridor -= 1;
                }
                else if (rnd <= 50 && GameController.Instance.hall > 0)
                {
                    Instantiate(hall, transform.position + transform.forward * roomSize, transform.rotation);
                    GameController.Instance.hall -= 1;
                }
                else
                    Instantiate(endRoom, transform.position + transform.forward * roomSize, transform.rotation);

            }
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(endRoom, transform.position + transform.forward * roomSize, transform.rotation);


            if (!Physics.Raycast(ray2, 10f) && !Physics.Raycast(ray22, 10f))
            {
                if (rnd > 50 && GameController.Instance.corridor > 0)
                {
                    Instantiate(corridor, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    GameController.Instance.corridor -= 1;
                }
                else if (rnd <= 50 && GameController.Instance.hall > 0)
                {
                    Instantiate(hall, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    GameController.Instance.hall -= 1;
                }
                else
                    Instantiate(endRoom, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
            }
            else if (!Physics.Raycast(ray2, 10f))
                Instantiate(endRoom, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));


            if (!Physics.Raycast(ray3, 10f) && !Physics.Raycast(ray33, 10f))
            {
                if (rnd > 50 && GameController.Instance.corridor > 0)
                {
                    Instantiate(corridor, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
                    GameController.Instance.corridor -= 1;
                }
                else if (rnd <= 50 && GameController.Instance.hall > 0)
                {
                    Instantiate(hall, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
                    GameController.Instance.hall -= 1;
                }
                else
                    Instantiate(endRoom, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
            }
            else if (!Physics.Raycast(ray3, 10f))
                Instantiate(endRoom, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
        }
    }
    
}
