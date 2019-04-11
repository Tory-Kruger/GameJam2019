using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadToryScript : MonoBehaviour {

    public KeyCode forwardsKey;
    public KeyCode backwardsKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public int playerSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(forwardsKey))
        {
            transform.position = transform.position * playerSpeed;
        }

        if (Input.GetKey(backwardsKey))
        {
            transform.position = transform.position * -playerSpeed;
        }

        if (Input.GetKey(leftKey))
        {
            transform.position = transform.position * playerSpeed;
        }

        if (Input.GetKey(rightKey))
        {
            transform.position = transform.position * playerSpeed;
        }
    }
}
