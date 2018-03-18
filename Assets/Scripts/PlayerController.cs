using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed = 5f;
    public float turningSpeed = 5f;
    private Rigidbody _rb;

    public Rigidbody rb
    {
        get
        {
            if(_rb==null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            return _rb;
        }
    }

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        transform.Rotate(0f, Input.GetAxis("Horizontal") * turningSpeed, 0f);
        rb.velocity = transform.rotation * new Vector3(0f, 0f, Input.GetAxis("Vertical")) * speed;
		
	}
}
