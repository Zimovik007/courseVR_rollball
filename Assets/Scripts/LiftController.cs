using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public float dy = 0.05f;
    
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + dy, transform.position.z);
        transform.position = newPosition;
        if (transform.position.y > 30.0 || transform.position.y < 0.0) 
        {
            dy = -dy;
        }
    }
}
