using Unity.VisualScripting;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 7;
    
    bool isPressed = false;
    public int buttonVal;
    private void Update()
    {
        if (isPressed)
        {
            horizontalInput = buttonVal;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");

        }
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            isPressed = false;
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            isPressed = false;
        }
    }
   public void ButtonClick(int val)
   {
        isPressed = true;
        buttonVal = val;
   }
}
