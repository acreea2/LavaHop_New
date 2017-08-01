using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour {
	public character character;
	public GameObject scoreDisplay;
	public GameObject levelDisplay;
	public highScore highScore;
	public int coinTotal;
	public static MyGameController instance = null;

	private GUIText levelDisplayText;
	private GUIText scoreDisplayText;

	private GameObject exit;

	public void reloadLevel() {
		GameManager.instance.reloadLevel ();
	}

	public void incrementLevel() {
//		highScore.recordTime (timer);
		int nextLevel = GameManager.instance.incrementLevel ();

		levelDisplayText.text = "Level: " + nextLevel;
		character.score = 0;
	}

	public void updateScoreDisplay() {
		scoreDisplayText.text = "Coins: " + character.score + "/" + coinTotal;
	}

	public void showExit() {
		exit.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		scoreDisplayText = scoreDisplay.GetComponent<GUIText>();
		levelDisplayText = levelDisplay.GetComponent<GUIText>();
		coinTotal = GameObject.FindGameObjectsWithTag ("Collectible").Length;

		exit = GameObject.Find("Portal_All");
		exit.SetActive (false);
		updateScoreDisplay ();
	}
}
