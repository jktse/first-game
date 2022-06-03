using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 1000f;
    //public float moveSpeed = 3;
    public float sidewaysForce = 100f;

    // It is better to make physic call in FixedUpdate rather than Update
    void FixedUpdate()
    {
        // Note this entire based on the frame rate of the game
        // A fast computer has higher frame rate more update calls
        // Similarly if frame rate tanks due to the computer, the update calls is less.

        // Multiply by deltaTime which is the amount of time from the update call. Thus we are not
        // Dependent on the fps of the computer

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //moveSpeed += 0.01f;



        // There are better ways to check for player inputs
        // Also since in FixedUpdate, we might miss some player inputs.
        // It should be in update, thus we can consider having a bool to tell when these keys are pressed to update the force.
        if (Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
