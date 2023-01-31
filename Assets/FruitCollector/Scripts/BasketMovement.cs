using Unity.VisualScripting;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 7;
    bool isPressed = false;
    public float buttonVal;
    public int direction = 1;
    private void Update()
    {
        if (isPressed)
        {

            if (buttonVal <= 0)
            {
                buttonVal = direction;

            }
            else if (buttonVal >= 1)
            {
                buttonVal = 1;
            }
        }
        else
        {
            buttonVal = Input.GetAxis("Horizontal");

        }
        horizontalInput = buttonVal;

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(transform.position.x, - 4.5f, transform.position.z);
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
   public void ButtonClick(int val)
   {
        Debug.Log("call");
        isPressed = true;
        direction = val; 
   }
    public void ButtonClickCancle()
    {
        isPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bomb"))
        {
            collision.collider.GetComponent<Rigidbody>().useGravity = false;
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
            collision.collider.gameObject.transform.SetParent(gameObject.transform);
        }
       
    }

    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.collider.CompareTag("Bomb"))
        {*/
          //  collision.collider.GetComponent<Rigidbody>().useGravity = true;
        //}
    }


}
