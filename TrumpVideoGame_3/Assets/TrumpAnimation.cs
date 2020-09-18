// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// //using UnityStandardAssets.CrossPlatformInput;
// using UnityEngine.UI;
// //using UnityStandardAssets.Characters.FirstPerson;


// public class TrumpAnimation : MonoBehaviour
// {
    // // Start is called before the first frame update
	// private Animation anim;
// //	private RigidbodyFirstPersonController rb;
	
	// public float turnSmoothTime= 0.1f;
	// private float turnSmoothVelocity;
	
	// public Transform cam; 

	// //public FixedJoystick MoveJoystick;

	
    // void Start()
    // {
		// anim = GetComponent<Animation> ();
		// //rb = GetComponent<Rigidbody> ();
		// //rb= GetComponent<RigidbodyFirstPersonController>();

        
    // }

    // // Update is called once per frame
    // void Update()
    // {
		
		
       

		// float x = Input.GetAxisRaw("Horizontal");
		// float y = Input.GetAxisRaw("Vertical");
		
		
		
		// //transform.position += new Vector3(0,0,y/100);
		// //transform.position += new Vector3(x/100,0,0);

		// //Vector3 movement = new Vector3(x, 0.0f, y).normalized;

		// //enter trumps speed here!!!
		// //rb.velocity = movement * 4f;
		
		
		// //var fps = GetComponent<RigidbodyFirstPersonController>();
		// // x!=0 || y!=0 
		// //RigidbodyFirstPersonController rbfpc= new RigidbodyFirstPersonController();
		

		// if (  x!=0 || y!=0 ) {
			// float targetangle=Mathf.Atan2 (x, y) * Mathf.Rad2Deg + cam.eulerAngles.y; //(addition) 		 //to change the character in the direction the camera is facing

			// float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle,ref turnSmoothVelocity,turnSmoothTime);
			// transform.eulerAngles = new Vector3 (transform.eulerAngles.x,angle , transform.eulerAngles.z);
			
			// // Vector3 moveDirection= Quaternion.Euler(x,targetangle,y)*Vector3.forward;
			// // rb.velocity = moveDirection.normalized * 4f;
			// anim.Play ("walk");
		// } else {
			// anim.Play ("idle");
		// }

    // }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class TrumpController : MonoBehaviour {

	private Animation anim;

	private Rigidbody rb;

	//public Transform cam;
	public float turnSmoothTime= 0.1f;
	private float turnSmoothVelocity;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		//transform.position += new Vector3(0,0,y/10);
		//transform.position += new Vector3(x/10,0,0);

		Vector3 movement = new Vector3 (x, 0.0f, y);

		//enter trumps speed here!!!
		rb.velocity = movement * 4f;

		if (x != 0 || y != 0) {
			float targetangle=Mathf.Atan2 (x, y) * Mathf.Rad2Deg ;//+ cam.eulerAngles.y; //(addition) 		 //to change the character in the direction the camera is facing

			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle,ref turnSmoothVelocity,turnSmoothTime);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x,angle , transform.eulerAngles.z);
			
			Vector3 moveDirection= Quaternion.Euler(x,targetangle,y)*Vector3.forward;
			rb.velocity = moveDirection.normalized * 4f;
		}

		if (x != 0 || y != 0) {
			anim.Play ("walk");
		} else {
			anim.Play ("idle");
		}
	}	
}

