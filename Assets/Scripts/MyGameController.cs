using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour {
	public character character;

	private int coinTotal;
	private GameObject scoreDisplay;
	private GameObject levelDisplay;
	private GameObject highScore;
	private HighScore highScoreScript;
	private GameObject timer;
	private Timer timerScript;
	private GUIText levelDisplayText;
	private GUIText scoreDisplayText;
	private GameObject exit;

	// Use this for initialization
	void Start () {
		timer = GameObject.Find ("timer");
		highScore = GameObject.Find ("highScore");
		highScoreScript = (HighScore) highScore.GetComponent (typeof(HighScore));
		timerScript = (Timer) timer.GetComponent (typeof(Timer));
		scoreDisplay = GameObject.Find ("scoreDisplayText");
		levelDisplay = GameObject.Find ("levelDisplayText");
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
