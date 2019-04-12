using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	[Header("UI Objects")]
	public Text p1ScoreText;
	public Text p2ScoreText;
	public Text timerText;

	[Space]
	public GameObject winScreen;

	[Header("Gameplay")]
	public float roundTime = 90;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		timer = roundTime;
		if (winScreen)
		{
			winScreen.SetActive(false);
		}
		else
		{
			Debug.LogWarning("GameManager doesn't have a win screen!", this);
		}

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
		if (timer > 0)
		{
			p1ScoreText.text = coloredBlocks[0].ToString();
			p2ScoreText.text = coloredBlocks[1].ToString();

			timer -= Time.deltaTime;
			timerText.text = ((int)timer).ToString("00");
		}
		else
		{
			timerText.text = "00";
			if (winScreen) { winScreen.SetActive(true); }
		}
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
