 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ControlBall : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent <Rigidbody> ();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Land"){
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Land")
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Vertical");
        float moveVertical = -Input.GetAxis("Horizontal");

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
        // multiplying it by 'speed' - our public player speed that appears in the inspector
        rb.AddTorque(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.AddForce(jump* jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
