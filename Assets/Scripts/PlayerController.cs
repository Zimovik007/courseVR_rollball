﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public GameObject player;
    public Text task;
    public Text HealthText;
    public GameManager gameManager = GameManager.Instance;

    public int cntCapsules = 3;

    public bool onGround = true;

    void DeadPlayer()
    {
        gameManager.decHealth();
        HealthText.text = "Количество жизней: " + gameManager.health.ToString();
        if (gameManager.health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HealthText.text = "Количество жизней: " + gameManager.health.ToString();
        task.text = "Задание: Собрать капсул - " + cntCapsules.ToString();
    }
    
    void Update()
    {
    }

    void FixedUpdate()
    {
        bool jump = Input.GetKey(KeyCode.Space);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (jump && onGround)
        {
            onGround = false;
            Vector3 jumpMovement = new Vector3(moveHorizontal, 50.0f, moveVertical);
            rb.AddForce(jumpMovement * speed);
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;

        if (collision.gameObject.name == "Capsule")
        {
            Destroy(collision.gameObject);
            cntCapsules--;
            if (cntCapsules == 0)
            {
                task.text = "Задания выполнены";
            }
            else
            {
                task.text = "Задание: Собрать капсул - " + cntCapsules.ToString();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "GameObject")
        {
            DeadPlayer();
        }
    }
}
