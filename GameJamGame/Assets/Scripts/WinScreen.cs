using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

	void OnEnable()
	{
		// figure out who won
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
