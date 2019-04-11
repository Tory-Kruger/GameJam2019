using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public float _respawnTime = 2.0f;
	public float _respawnHeight = -1000.0f;
	public Transform _resetPos;

	public float timer = 0;

	// Update is called once per frame
	void Update ()
	{
		bool reset = false;

		if (!(Physics.Raycast(transform.position, Vector3.down, 10000.0f)) && timer < float.Epsilon)
			timer = Time.time;

		if ((timer - Time.time) > _respawnTime && timer > 0)
			reset = true;

		if (transform.position.y < _respawnHeight)
			reset = true;

		if (reset)
			Reset();
	}

	private void Reset()
	{
		transform.position = _resetPos.position;
		GetComponent<CharacterController>().transform.position = _resetPos.position;
		timer = 0;
	}
}
