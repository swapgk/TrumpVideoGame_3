using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public float jumpHeight = 3f;

    // To check if we are on the ground and reset the velocity.y=0;
    public Transform groundCheck1;// reference to the object GroundCheck
    public Transform groundCheck2;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; // to decide what objects should the groundCheck check for
    bool isGrounded1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // To check if we are on the ground and reset the velocity.y=0;
        isGrounded1 = Physics.CheckSphere(groundCheck1.position, groundDistance, groundMask);
        //isGrounded = Physics.CheckBox(groundCheck.position,)

        if (isGrounded1 && velocity.y <0)
        {
            velocity.y = -2f;
        }

        //Jump
        if (Input.GetButton("Jump") && isGrounded1 )
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // v= squrt(2gh)
        }

        //Adding gravity, we make the y velocity of the player
       
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        

        float x = 0;
        float z = 0;

        //take in input from WASD
       
         x = Input.GetAxis("Horizontal");
         z = Input.GetAxis("Vertical");
        

        //Vector3 move = new Vector3(x, 0f, z);  // this is with reference with the global cordinates
        Vector3 move = (transform.right * x + transform.forward * z).normalized;// this is wrt the player(character controller)
        // Now to move our player we need a reference to the CharacterController so line 10
        controller.Move(move * speed * Time.deltaTime);

        
    }
}
