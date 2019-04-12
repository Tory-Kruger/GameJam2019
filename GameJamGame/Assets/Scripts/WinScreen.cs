using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

	public Text displayWinner;
	public string winMessge;
	public string drawMessage;

	void OnEnable()
	{
		// figure out who won
		GameManager gm = FindObjectOfType<GameManager>();
		int p1 = gm.coloredBlocks[0];
		int p2 = gm.coloredBlocks[1];

		if (p1 > p2)
		{
			displayWinner.text = "Player 1 " + winMessge;
		}
		else if (p2 > p1)
		{
			displayWinner.text = "Player 2 " + winMessge;
		}
		else
		{
			displayWinner.text = drawMessage;
		}
	}

	public void OnRestartPressed()
	{
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index);
	}

	public void OnExitPressed(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
}
