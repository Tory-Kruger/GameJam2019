using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ColorCaster))]
public class PlayerController : MonoBehaviour {

	[Header("Controls")]
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode jump = KeyCode.RightControl;
	public KeyCode attack = KeyCode.RightShift;

	[Header("Movement")]
	public float gravity = -9.81f;
	public float movSpeed = 20;
	public float rotSpeed = 130;
	public float jmpForce = 500;
	public float jmpSmoothTime = .25f;

	[Header("Combat")]
	public float attackRange = 3;
	public float attackForce = 20;
	public float attackJump = 25f;
	public float attackDeceleration = 0.04f;
	private Vector3 appliedAttackForce;

	[Space]
	public Animator animator;

	private CharacterController controller;

	private float movInput = 0;
	private float rotInput = 0;
	private float jmpInput = 0;

	private Vector3 velocity;

	private float jmpVelocity;

	private PlayerController otherPlayer;

	private ColorCaster colorCaster;
	public Players PlayerTag { get { return colorCaster.playerTag; } }

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		velocity = Vector3.zero;
		otherPlayer = new List<PlayerController>(FindObjectsOfType<PlayerController>()).Find(p => p != this);
		colorCaster = GetComponent<ColorCaster>();

		if (!animator)
		{
			Debug.LogWarning("Player does not have an attack animation!", this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		DoMovement();

		if (Input.GetKeyDown(attack))
		{
			DoAttack();
		}
	}

	void DoMovement()
	{
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
		Vector3 vUpward = Vector3.up * (jmpInput + gravity);
		Vector3 vUpLerp = Vector3.zero;
		vUpLerp.y = Mathf.SmoothDamp(velocity.y, vUpward.y, ref jmpVelocity, jmpSmoothTime);

		velocity = vForward + vUpLerp;

		appliedAttackForce = Vector3.LerpUnclamped(appliedAttackForce, Vector3.zero, attackDeceleration);
		if (Vector3.Distance(appliedAttackForce, Vector3.zero) < .01f) { appliedAttackForce = Vector3.zero; }

		controller.Move((velocity + appliedAttackForce) * Time.deltaTime);
	}
	
	void DoAttack()
	{
		float distance = Vector3.Distance(transform.position, otherPlayer.transform.position) - (transform.localScale.x + otherPlayer.transform.localScale.x) / 2f;

		if (distance <= attackRange)
		{
			Vector3 calculatedForce = (otherPlayer.transform.position - transform.position).normalized * attackForce;
			calculatedForce.y = attackJump;
			otherPlayer.appliedAttackForce = calculatedForce;
		}

		if (animator)
		{
			animator.SetTrigger("Attack");
		}
	}
}
