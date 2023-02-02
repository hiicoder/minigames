using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;
    public float amplitude;
    public Vector3 tempPosition;
       Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempPosition = transform.position;
    }
    void FixedUpdate() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x, 0, z) * speed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)*amplitude;
       // transform.position = tempPosition;
       
    }

    
   

}
