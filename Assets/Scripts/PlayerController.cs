using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public GameObject player;

    IEnumerator StopVelocity()
    {
        while (true)
        {
            yield return null;
            Debug.Log(Time.deltaTime);
        }
    }

    public bool onGround = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (player.transform.position.y < 0.0f)
        {
            Debug.Log("УМЕР");
        }
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
    }
}
