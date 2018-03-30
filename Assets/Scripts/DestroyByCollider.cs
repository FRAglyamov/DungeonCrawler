
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollider : MonoBehaviour {

    float thisTime;
    bool done;
    void Start()
    {
        thisTime = Time.time + 1f;
        done = false;
    }

    private void Update()
    {
        if (thisTime < Time.time && !done)
        {
            Collider[] objs = Physics.OverlapCapsule(this.transform.position, transform.up * 10, 0.1f);

            if (objs.Length > 2)
            {
                Debug.DrawRay(transform.position, transform.up * 10, Color.cyan, 100f);
                Destroy(this.gameObject);
                foreach (var item in objs)
                {
                    Debug.Log(this.gameObject.name + " - " + item.name);
                }
            }
            done = true;
        }
    }
}
