using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour {

	public Text highScoreText;

	private int currentLevel;
	private float bestTime;

	// Use this for initialization
	void Start () {
		currentLevel = GameManager.instance.level;
		bestTime = PlayerPrefs.GetInt ("HighScoreLevel" + currentLevel, 0);

		if (bestTime > 0) {
			highScoreText.text = "Best Time: " + Timer.formatTime (bestTime);
		} else {
			highScoreText.text = "";
		}
	}

	public void recordTime(float newTime) {
		currentLevel = GameManager.instance.level;

		if (bestTime > newTime) {
			PlayerPrefs.SetFloat ("HighScoreLevel" + currentLevel, newTime);
		}
	}
}
