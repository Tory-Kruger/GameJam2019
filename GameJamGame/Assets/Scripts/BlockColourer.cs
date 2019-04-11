using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColourer : MonoBehaviour {

    private string currentTag = "Uncolored";

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.tag == "Colored")
		{
			string tag = collision.collider.tag;

			if (currentTag == tag) return;

			// Notify GameManager of color Change

			// Set new Color according to tag
		}
    }
}
