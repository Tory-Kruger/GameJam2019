using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColourer : MonoBehaviour {

    private Players currentTag = Players.NULL;
	private GameManager gameManager;

	// Update is called once per frame
	private void Start()
	{
		// Add to total count
		gameManager = FindObjectOfType<GameManager>();
		gameManager._blockCount++;
	}

	public void ChangeColor(Players tag)
	{
		if (currentTag == tag) return;

		// Notify GameManager of color Change
		gameManager.ChangeColoredCount(currentTag, tag);


		// Set new Color according to tag
		var color = gameManager.GetPlayerColor(tag);
		GetComponent<Renderer>().material.color = color;
		currentTag = tag;
	}
}
