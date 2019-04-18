using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	CharacterController	controller;
	public float 	movSpeed = 1;
	private Camera  camObj;
    public float    horizontalLookSpeed = 1.0f;
    public float    verticalLookSpeed = 1.0f;


    void Start()
	{
        Cursor.visible = false;
		camObj = Camera.main;
		controller = GetComponent<CharacterController> ();
	}

	void Update()
	{
        
        float rotSPeed = 0;
        rotSPeed = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1) * horizontalLookSpeed;
        transform.RotateAround(transform.position, Vector3.up, rotSPeed * Time.deltaTime);
        rotSPeed = Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1) * verticalLookSpeed;
        transform.RotateAround(transform.position, transform.right, -rotSPeed * Time.deltaTime);
        Plane p = new Plane(transform.position + transform.right,transform.position + Vector3.up,transform.position + (-transform.right));
        if(Vector3.Dot(p.normal,transform.forward) < 0)
         transform.RotateAround(transform.position, transform.right, rotSPeed * Time.deltaTime);
        Vector3 dirToMov = Vector3.zero;
        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
		{
            dirToMov = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
			controller.Move (dirToMov * (movSpeed * Time.deltaTime));
		}
		else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
		{
            dirToMov = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
            controller.Move (-dirToMov * (movSpeed * Time.deltaTime));
		}
		else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
		{
			controller.Move (-transform.right * (movSpeed * Time.deltaTime));
		}
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			controller.Move (transform.right * (movSpeed * Time.deltaTime));
		}
	}
}