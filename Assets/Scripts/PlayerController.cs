﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
    public float speed = 5f;
    public float turningSpeed = 3f;

    private int maxHealth = 100;
    public int curHealth = 100;
    public Slider healthSlider;

    public LayerMask enemyMask;

    AudioManager audioManager;

    Animator anim;
    float attackRate = 1.5f;
    float nextAttackTime = 1f;
    public GameObject spear;
    public GameObject hand;

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
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        Attack();
        //RangeAttack();
        Death();
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, Input.GetAxis("Horizontal") * turningSpeed, 0f);
        anim.SetFloat("speed", Input.GetAxis("Vertical"));
        rb.velocity = transform.rotation * new Vector3(0f, 0f, Input.GetAxis("Vertical")) * speed;

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextAttackTime)
        {
            anim.SetTrigger("attack2");
            audioManager.Play("PlayerAttack");
            nextAttackTime = Time.time + attackRate;
            Collider[] hittedEnemy = Physics.OverlapBox(transform.position + transform.forward, new Vector3(1f, 0.5f, 0.5f), transform.rotation, enemyMask);
            foreach (Collider enemy in hittedEnemy)
            {
                Debug.Log(enemy.name);
                if (enemy.GetComponent<EnemyController>() != null)
                    enemy.GetComponent<EnemyController>().health -= 50;
                if (enemy.GetComponent<RangeEnemyController>() != null)
                    enemy.GetComponent<RangeEnemyController>().health -= 50;
            }
        }
    }
    void RangeAttack()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > nextAttackTime)
        {
            anim.SetTrigger("attack1");
            nextAttackTime = Time.time + attackRate;
            Instantiate(spear, hand.transform.position, Quaternion.identity);
        }
    }
    void Death()
    {
        if (curHealth <= 0)
        {
            anim.SetTrigger("death");
            gameObject.GetComponent<PlayerController>().enabled = false;
            audioManager.Play("Game Over");
        }
    }
    public void Damaged(int damage)
    {
        anim.SetTrigger("damaged");
        curHealth -= damage;
        this.healthSlider.value = curHealth;
    }
    public void Healed(int heal)
    {
        curHealth += heal;
        this.healthSlider.value = curHealth;
    }
}
