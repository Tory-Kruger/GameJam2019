using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCaster : MonoBehaviour {

	public Players playerTag = Players.NULL;

	// Update is called once per frame
	void Update ()
	{
		if (playerTag == Players.NULL)
			return;

		RaycastHit info;
		float distance = (transform.localScale.y * 0.5f + 0.1f);
		if (!Physics.Raycast(transform.position, Vector3.down, out info, distance))
			return;

		var colourer = info.collider.GetComponent<BlockColourer>();
		if (colourer)
		{
			colourer.ChangeColor(playerTag);
		}
	}
}
