using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    private float targetAngle = 0;
    private bool positionChange = false;
    const float rotationAmount = 10.0f;
    public float rDistance = 1.0f;
    public float rSpeed = 3.0f;
    public const float PI = 3.141592653589f;

    public GameManager gameManager = GameManager.Instance;

    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (targetAngle == 0.0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                targetAngle -= 90.0f;
                positionChange = true;
                gameManager.changeIndex(-1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                targetAngle += 90.0f;
                positionChange = true;
                gameManager.changeIndex(1);
            }
        }

        if (targetAngle != 0)
        {
            ChangePosition();
            positionChange = false;
            Rotate();
        }
    }

    protected void ChangePosition()
    {
        if (!positionChange)
        {
            return;
        }

        float phi = targetAngle * (PI / 180);
        float nextX = player.transform.position.x + (transform.position.x - player.transform.position.x) * Mathf.Cos(phi) - (transform.position.z - player.transform.position.z) * Mathf.Sin(phi); 
        float nextY = player.transform.position.z + (transform.position.x - player.transform.position.x) * Mathf.Sin(phi) + (transform.position.z - player.transform.position.z) * Mathf.Cos(phi);

        Vector3 to = new Vector3(nextX, transform.position.y, nextY);

        transform.position = to;
        offset = transform.position - player.transform.position;
    }

    protected void Rotate()
    {

        float step = rSpeed * Time.deltaTime;
        float orbitCircumfrance = 2F * rDistance * Mathf.PI;
        float distanceDegrees = (rSpeed / orbitCircumfrance) * 360;
        float distanceRadians = (rSpeed / orbitCircumfrance) * 2 * Mathf.PI;
        
        if (targetAngle > 0)
        {
            transform.RotateAround(transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }
    }

    void Update()
    {

        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) && rotate)
        //{
        //rotate = false;

        //rotateDegrees -= 90;

        // transform.RotateAround(player.transform.position, Vector3.up, -1.0f);

        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, rotateDegrees, 0), 100);

        //}
        // else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && rotate)
        // {
        //    rotate = false;

        //   rotateDegrees += 90;

        //    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, rotateDegrees, 0), 100);

        // }
        //    else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        //    {
        //    rotate = true;
        // }

    }
}
