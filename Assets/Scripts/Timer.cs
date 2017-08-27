using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private float startTime;
	private Text displayText;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		displayText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		displayText.text = formatTime(timeElapsed());
	}

	public float timeElapsed() {
		return Time.time - startTime;
	}

	public static string formatTime(float t) {
		float minutes = ((int)t / 60);
		float seconds = (t % 60);

		return leadingZeros(minutes) + ":" + leadingZeros(seconds);
	}

	static string leadingZeros(float num) {
		return (num < 10)
			? "0" + num.ToString("f2")
			: num.ToString("f2");
	}

	public static string formatTimeForScoreBoard(float t) {
		if (t <= 0) {
			return "-";
		}
		float hours = Mathf.Floor (t / 60 / 60);
		float minutes = Mathf.Floor ((t - (hours * 60)) / 60);
		float seconds = Mathf.Round ((t - (hours * 60 * 60) - (minutes * 60)));

		string[] output = new string[3];
		if (hours > 0) {
			output[0] = hours.ToString() + "h";
		}
		output[1] += minutes.ToString() + "m";
		output[2] += seconds.ToString() + "s";

		return string.Join (" ", output);
	}
}