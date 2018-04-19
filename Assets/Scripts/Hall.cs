using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : MonoBehaviour {

    public GameObject Corridor;
    public GameObject EndRoom;
    public GameObject HallRoom;

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

            //Check(ray1, 0f);
            //Check(ray2, 90f);
            //Check(ray3, -90f);



            if (!Physics.Raycast(ray1, 10f) && !Physics.Raycast(ray11, 10f))
                Instantiate(Corridor, transform.position + transform.forward * roomSize, transform.rotation);
            else if (!Physics.Raycast(ray1, 10f))
                Instantiate(EndRoom, transform.position + transform.forward * roomSize, transform.rotation);


            if (!Physics.Raycast(ray2, 10f) && !Physics.Raycast(ray22, 10f))
                Instantiate(Corridor, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
            else if (!Physics.Raycast(ray2, 10f))
                Instantiate(EndRoom, transform.position + transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, 90f, 0f));


            if (!Physics.Raycast(ray3, 10f) && !Physics.Raycast(ray33, 10f))
                Instantiate(Corridor, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
            else if (!Physics.Raycast(ray3, 10f))
                Instantiate(EndRoom, transform.position - transform.right * roomSize, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
        }
    }

    public void Check(Ray ray, float rotation)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if ((hit.transform.name.StartsWith("EndRoom") && (hit.transform.rotation != transform.rotation * Quaternion.Euler(0f, rotation, 0f)))
                || (hit.transform.name.StartsWith("Corridor") && (hit.transform.rotation != transform.rotation * Quaternion.Euler(0f, rotation, 0f)) && (hit.transform.rotation != transform.rotation * Quaternion.Euler(0f, -rotation, 0f))))
            {
                Debug.DrawRay(transform.position, transform.up, Color.cyan, 200f);
                Instantiate(EndRoom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    
}
