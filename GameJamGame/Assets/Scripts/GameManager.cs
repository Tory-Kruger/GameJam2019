using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Players
{
	P1 = 0,
	P2,

	NULL
}

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int _blockCount;
	[HideInInspector]
	public List<int> coloredBlocks = new List<int>();
	private List<Color> playerColors = new List<Color>();

	[Header("Player Colors")]
	public Color p1Color;
	public Color p2Color;

	// Use this for initialization
	void Start ()
	{
		playerColors.Add(p1Color);
		playerColors.Add(p2Color);

		for (int i = 0; i <= (int)Players.NULL; ++i)
		{
			coloredBlocks.Add(0);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update UI?
	}

	public void ChangeColoredCount(Players before, Players after)
	{
		coloredBlocks[(int)before] = coloredBlocks[(int)before] - 1;
		coloredBlocks[(int)after] = coloredBlocks[(int)after] + 1;
	}

	public Color GetPlayerColor(Players player)
	{
		return playerColors[(int)player];
	}
}
