using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	[Header("Controls")]
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode jump = KeyCode.RightControl;

	[Header("Movement")]
	public Vector3 gravity = Physics.gravity;
	public float movSpeed = 20;
	public float rotSpeed = 130;
	public float jmpForce = 250;

	private CharacterController controller;

	private float movInput = 0;
	private float rotInput = 0;
	private float jmpInput = 0;

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		// get input
		rotInput = 0;
		movInput = 0;
		jmpInput = 0;

		if (Input.GetKey(right))
		{
			rotInput = rotSpeed;
		}
		if (Input.GetKey(left))
		{
			rotInput = -rotSpeed;
		}
		if (Input.GetKey(forward))
		{
			movInput = movSpeed;
		}
		if (Input.GetKey(backward))
		{
			movInput = -movSpeed;
		}
		if (Input.GetKeyDown(jump) && controller.isGrounded)
		{
			jmpInput = jmpForce;
		}

		// movement
		transform.Rotate(Vector3.up, rotInput * Time.deltaTime);

		Vector3 vForward = transform.forward * movInput;
		Vector3 vUpward = Vector3.up * jmpInput + gravity;
		Vector3 vUpLerp = Vector3.Lerp(new Vector3(0, velocity.y, 0), vUpward, .25f);

		velocity = vForward + vUpLerp;

		velocity.x = Mathf.Clamp(velocity.x, -movSpeed, movSpeed);
		velocity.z = Mathf.Clamp(velocity.z, -movSpeed, movSpeed);
		velocity.y = Mathf.Clamp(velocity.y, gravity.y, jmpForce);

		controller.Move(velocity * Time.deltaTime);
	}
}
