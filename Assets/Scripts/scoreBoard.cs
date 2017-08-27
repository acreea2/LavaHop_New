using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class scoreBoard : MonoBehaviour {
	private TextMesh levelDisplay;
	private TextMesh scoreDisplay;
	
	void Start () {
		string prefSlug = GameManager.highScoreSlug;
		string level = Regex.Match (name, @"\d+").Value;

		levelDisplay = transform.Find ("Level").GetComponent<TextMesh> ();
		levelDisplay.text = level;

		scoreDisplay = transform.Find ("Score").GetComponent<TextMesh> ();
		scoreDisplay.text = Timer.formatTimeForScoreBoard (
			PlayerPrefs.GetFloat (prefSlug + level, 0)
		);
	}

	private string formatLevel(int level) {
		if (level < 10) {
			return "0" + level.ToString ();
		}
		return level.ToString ();
	}
}
