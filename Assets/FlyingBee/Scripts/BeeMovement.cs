using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    public float verticalSpeed;
    public float amplitude;
    public Vector3 tempPosition;
       Rigidbody rb;
    public Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    public Quaternion rotation2 = Quaternion.Euler(80, 0, 0);
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
        if (Input.GetAxis("Vertical") >0.1)
        {
            rb.MoveRotation( Quaternion.Slerp(rotation1, rotation2, 1f / rotSpeed));
        }
        else
        {
            rb.MoveRotation(Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), 0));
        }


    }

    
   

}
