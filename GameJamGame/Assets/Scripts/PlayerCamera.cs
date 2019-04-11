using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.04f;
	public float slerpT = 0.1f;

	private Vector3 velocity;

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, slerpT);
	}
}
