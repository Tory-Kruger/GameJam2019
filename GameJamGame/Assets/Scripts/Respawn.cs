using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public float _respawnHeight = -20.0f;
	public Transform _resetPos;

	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y < _respawnHeight)
			transform.position = _resetPos.position;
	}
}
