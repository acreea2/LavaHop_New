using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {
	public int startingLevel;
	private TextMesh displayText;
	
	void Start () {
		displayText = GetComponent<TextMesh> ();
		displayText.text = populateScoreboard();
	}

	string populateScoreboard() {
		string prefSlug = GameManager.highScoreSlug;
		string scoreBoardText = "";
		int lastLevelToDisplay = Mathf.Min (startingLevel + 4, GameManager.instance.levelCount);

		for (int level = startingLevel; level <= lastLevelToDisplay; level++) {
			scoreBoardText += formatLevel (level)
			+ ": "
			+ Timer.formatTimeForScoreBoard(
					PlayerPrefs.GetFloat (prefSlug + level.ToString (), 0)
				)
			+ "\n";
		}

		return scoreBoardText;
	}

	private string formatLevel(int level) {
		if (level < 10) {
			return "0" + level.ToString ();
		}
		return level.ToString ();
	}
}
