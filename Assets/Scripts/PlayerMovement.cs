using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000;
    public float sidewaysForce = 400;
    private float screenCenterX;

    private void Start()
    {
        // save the horizontal center of the screen
        screenCenterX = Screen.width * 0.5f;
    }
 
    // Update is called once per frame
    private void FixedUpdate() {
        
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (touch.position.x < screenCenterX)
                {
                    // if the touch position is to the left of center
                    // move left
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }

            }
        }
        if ( Input.GetKey("d") || Input.GetKey("right") ) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
