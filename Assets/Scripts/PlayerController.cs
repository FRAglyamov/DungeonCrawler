using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
    public float speed = 5f;
    public float turningSpeed = 5f;

    private int maxHealth = 100;
    public int curHealth = 100;
    public Slider healthSlider;

    public LayerMask enemyMask;

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
        healthSlider.value = curHealth;
    }

    private void Update()
    {
        Attack();
        BowAttack();
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, Input.GetAxis("Horizontal") * turningSpeed, 0f);
        rb.velocity = transform.rotation * new Vector3(0f, 0f, Input.GetAxis("Vertical")) * speed;

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            Collider[] hittedEnemy = Physics.OverlapBox(transform.position + transform.forward, new Vector3(1f, 0.5f, 0.5f), transform.rotation, enemyMask);
            foreach (Collider enemy in hittedEnemy)
            {
                Debug.Log(enemy.name);
                if (enemy.GetComponent<GhostController>() != null)
                    enemy.GetComponent<GhostController>().health -= 50;
            }
        }
    }
    void BowAttack()
    {
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
        {
            //Instantiate(arrow, hand.position, Quaternion.identity);
        }
    }

    //Camera cam;
    //private void Start()
    //{
    //    cam = Camera.main;
    //}
    //private void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if(Physics.Raycast(ray, out hit))
    //        {

    //        }
    //    }
    //}
}
