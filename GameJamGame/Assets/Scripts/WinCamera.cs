using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WinCamera : MonoBehaviour {

	public Vector3 lookAtTarget;
	public float speed;

	private bool gameOver;

	[HideInInspector]
	public new Camera camera;

	private void OnEnable()
	{
		camera = GetComponent<Camera>();
		gameOver = true;
	}

	private void Update()
	{
		if (gameOver)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.LookAt(lookAtTarget);
		}
	}
}
