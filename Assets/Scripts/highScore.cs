using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	private Text displayText;

	private int currentLevel;
	private float bestTime;
	private string prefSlug;

	// Use this for initialization
	void Start () {
		displayText = GetComponent<Text> ();
		currentLevel = GameManager.instance.level;
		prefSlug = GameManager.highScoreSlug + currentLevel;

		bestTime = PlayerPrefs.GetFloat (prefSlug, 0);
		if (bestTime > 0) {
			displayText.text = "High Score: " + Timer.formatTime (bestTime);
		} else {
			displayText.text = "High Score: n/a";
		}
	}

	public void recordTime(float newTime) {
		currentLevel = GameManager.instance.level;

		if (bestTime == 0 || bestTime > newTime) {
			PlayerPrefs.SetFloat (prefSlug, newTime);
		}
	}
}
