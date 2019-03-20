using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    public bool rotate = true;
    public int rotateDegrees = 0;

    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
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
