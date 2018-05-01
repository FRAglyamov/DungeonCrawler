using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour {

    public GameObject endRoom;
    public GameObject corridor;
    public GameObject hall;

    void Start ()
    {
        int roomSize = GameController.roomSize;
        if (!GameController.Instance.isLoad)
        {

            Ray ray1 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * roomSize, transform.up * 10);
            Ray ray11 = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 2 * roomSize, transform.up * 10);


            RaycastHit hit;
            if(Physics.Raycast(ray1, out hit, 10f))
            {
                if ((hit.transform.name.StartsWith("EndRoom") && (hit.transform.rotation != transform.rotation))
                    || (hit.transform.name.StartsWith("Corridor")&& (hit.transform.rotation != transform.rotation)))
                {
                    Debug.DrawRay(transform.position, transform.up, Color.red, 200f);
                    Instantiate(endRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }

            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
            {
                int rnd = Random.Range(0, 100);
                if (rnd > 50 && GameController.Instance.corridor > 0)
                {
                    Instantiate(corridor, transform.position + transform.forward * roomSize, transform.rotation);
                    GameController.Instance.corridor -= 1;
                }
                else if (GameController.Instance.hall > 0)
                {
                    Instantiate(hall, transform.position + transform.forward * roomSize, transform.rotation);
                    GameController.Instance.hall -= 1;
                }
                else
                    Instantiate(endRoom, transform.position + transform.forward * roomSize, transform.rotation);
            }
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(endRoom, transform.position + transform.forward * roomSize, transform.rotation);
        }
    }
}
