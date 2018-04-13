using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCorridor : MonoBehaviour {

    public GameObject WayRoom1;
    public GameObject WayRoom2;
    public GameObject WayRoom4;

    void Start ()
    {

        if (!GameController.Instance.isLoad)
        {

            Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 4, transform.up * 10);
            Ray ray11 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 8, transform.up * 10);


            RaycastHit hit;
            if(Physics.Raycast(ray1, out hit, 10f))
            {
                if ((hit.transform.name.StartsWith("1-Way") && (hit.transform.rotation != transform.rotation * Quaternion.Euler(0f, 180f, 0f)))
                    || (hit.transform.name.StartsWith("Corridor")&& (hit.transform.rotation != transform.rotation)))
                {
                    Debug.DrawRay(transform.position, transform.up, Color.red, 200f);
                    Instantiate(WayRoom1, transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                    Destroy(gameObject);
                }
            }

            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
            {
                int rnd = Random.Range(0, 100);
                if (rnd > 50 && GameController.Instance.WayRoom2 > 0)
                {
                    Instantiate(WayRoom2, transform.position + transform.forward * 4, transform.rotation);
                    GameController.Instance.WayRoom2 -= 1;
                }
                else if (GameController.Instance.WayRoom4 > 0)
                {
                    Instantiate(WayRoom4, transform.position + transform.forward * 4, transform.rotation);
                    GameController.Instance.WayRoom4 -= 1;
                }
                else
                    Instantiate(WayRoom1, transform.position + transform.forward * 4, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            }
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(WayRoom1, transform.position + transform.forward * 4, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
