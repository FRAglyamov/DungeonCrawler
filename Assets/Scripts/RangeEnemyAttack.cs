using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour {

    private Rigidbody _rb;

    public Rigidbody rb
    {
        get
        {
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            return _rb;
        }
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * 4f;
        
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Damaged(10);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
