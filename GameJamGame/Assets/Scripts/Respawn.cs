using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public float _respawnTime = 2.0f;
	public float _respawnHeight = -1000.0f;
	public Transform _resetPos;

	private float timer;
	
	// Update is called once per frame
	void Update ()
	{
		bool reset = false;

		if (Physics.Raycast(transform.position, Vector3.down, 100.0f))
			timer = Time.time;

		reset |= ((timer - Time.time) > _respawnTime);
		reset |= transform.position.y < _respawnHeight;

		if (reset)
			transform.position = _resetPos.position;
	}
}
