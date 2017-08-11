using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour {
	public character character;
	public GameObject scoreDisplay;
	public GameObject levelDisplay;
	public int coinTotal;
	public static MyGameController instance = null;

	public GameObject highScore;
	public HighScore highScoreScript;
	public GameObject timer;
	public Timer timerScript;

	private GUIText levelDisplayText;
	private GUIText scoreDisplayText;

	private GameObject exit;

	// Use this for initialization
	void Start () {
		timer = GameObject.Find ("timer");
		highScore = GameObject.Find ("highScore");
		highScoreScript = (HighScore) highScore.GetComponent (typeof(HighScore));
		timerScript = (Timer) timer.GetComponent (typeof(Timer));
		scoreDisplayText = scoreDisplay.GetComponent<GUIText>();
		levelDisplayText = levelDisplay.GetComponent<GUIText>();

		coinTotal = GameObject.FindGameObjectsWithTag ("Collectible").Length;

		exit = GameObject.Find("Portal_All");
		exit.SetActive (false);
		updateScoreDisplay ();
	}

	public void reloadLevel() {
		GameManager.instance.reloadLevel ();
	}

	public void incrementLevel() {
		highScoreScript.recordTime (timerScript.timeElapsed());
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
}
